using Frontend.Models;
using Frontend.ViewModel;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using ToastNotifications.Messages;

namespace Frontend.Helpers
{
    public sealed class APIClient
    {
        private static readonly APIClient instance = new APIClient();
        private RestClient _client;
        private RestRequest _request;

        static APIClient()
        {

        }
        private APIClient()
        {
            _client = new RestClient(ConfigurationManager.AppSettings.Get("server.url"));
        }
        public static APIClient Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<bool> SendLogin(string username, string password)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            _request = new RestRequest("authentication/login", Method.POST);
            _request.AddHeader("Content-Type", "application/json");
            _request.AddParameter("application/json", _request.AddJsonBody(new { username = username, password = password }), ParameterType.RequestBody);

            var response = await _client.ExecuteTaskAsync(_request, cancellationTokenSource.Token);
            cancellationTokenSource.Dispose();
            if (response.IsSuccessful)
            {
                LoginResponse LoginResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content.ToString());
                _client.Authenticator = new JwtAuthenticator(LoginResponse.AuthenticationToken);
                UserInformation.Instance.UserId = LoginResponse.UserId;
                UserInformation.Instance.IsAdmin = LoginResponse.userRight.Equals(LoginResponse.Rights.ADMIN.ToString());
                
                
                return true;
            }
            return false;
        }

        public void Logout()
        {
            _client = new RestClient("http://localhost:8080/");
        }


        public async Task<IRestResponse> NewPOSTRequest(string restEndpoint, object jsonBody)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            _request = new RestRequest(restEndpoint, Method.POST);
            _request.AddHeader("Accept", "application/json");
            _request.AddHeader("Content-Type", "application/json");
            _request.AddJsonBody(jsonBody);

            var response = await _client.ExecuteTaskAsync(_request, cancellationTokenSource.Token);
            if ((int)response.StatusCode >= 400 && LoginPageViewModel.Instance.IsLoggedIn)
            {
                MainViewModel.Instance.HandleHttpError((int)response.StatusCode);
            }
            
           
            cancellationTokenSource.Dispose();
            return response;
        }

        public async Task<IRestResponse> NewDELETERequest(string restEndpoint)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            _request = new RestRequest(restEndpoint, Method.DELETE);
            _request.AddHeader("Accept", "application/json");
            _request.AddHeader("Content-Type", "application/json");
           

            var response = await _client.ExecuteTaskAsync(_request, cancellationTokenSource.Token);

            cancellationTokenSource.Dispose();
            return response;
        }

        public async Task<IRestResponse> NewGETRequest(string restEndpoint)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            _request = new RestRequest(restEndpoint, Method.GET);
            _request.AddHeader("Accept", "application/json");
            _request.AddHeader("Content-Type", "application/json");
            
            var response =  await _client.ExecuteTaskAsync(_request, cancellationTokenSource.Token);
            if ((int)response.StatusCode >= 400)
            {
                MainViewModel.Instance.HandleHttpError((int)response.StatusCode);
            } else if(response.ResponseStatus == ResponseStatus.TimedOut)
            {
                MainViewModel.Instance.HandleHttpError(-1);
                cancellationTokenSource.Dispose();
                return response;
            }
            cancellationTokenSource.Dispose();
            return response;
        }

        public async Task<IRestResponse> NewFileUploadRequest(string restEndpoint, string path)
        {
            RestRequest _request = new RestRequest(restEndpoint, Method.POST);
            _request.RequestFormat = DataFormat.Json;
            _request.AddHeader("Content-Type", "multipart/form-data");
            _request.AddFile("file", path, "file");
            var response = await _client.ExecuteTaskAsync(_request);

            return response;
        }
    }
}
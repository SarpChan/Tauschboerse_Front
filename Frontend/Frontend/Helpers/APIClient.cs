using Frontend.ViewModel;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
            _client = new RestClient("http://localhost:8080/");
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
                _client.Authenticator = new JwtAuthenticator(response.Content);
                return true;
            }
            return false;
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
                MainViewModel.Instance.Logout(2);
            }
            cancellationTokenSource.Dispose();
            return response;
        }

        public async Task<IRestResponse> NewGETRequest(string restEndpoint)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            _request = new RestRequest(restEndpoint, Method.GET);
            _request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");

            var response =  await _client.ExecuteTaskAsync(_request, cancellationTokenSource.Token);
            cancellationTokenSource.Dispose();

            return response;
        }
    }
}
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
        private RestClient client;
        private RestRequest request;

        static APIClient()
        {

        }
        private APIClient()
        {
            client = new RestClient("http://localhost:8080/");
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
            request = new RestRequest("authentication/login", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", request.AddJsonBody(new { username = username, password = password }), ParameterType.RequestBody);

            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Dispose();

            if (response.IsSuccessful)
            {
                client.Authenticator = new JwtAuthenticator(response.Content);
                return true;
            }
            return false;
        }


        public async Task<IRestResponse> NewPOSTRequest(string restEndpoint, object jsonBody)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            request = new RestRequest(restEndpoint, Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(jsonBody);

            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Dispose();
            return response;
        }

        public async Task<IRestResponse> NewGETRequest(string restEndpoint)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            request = new RestRequest(restEndpoint, Method.GET);
            request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");

            var response =  await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Dispose();

            return response;
        }
    }
}
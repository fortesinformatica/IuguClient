using System;
using System.Configuration;
using System.Threading.Tasks;
using IuguClientAPI.Models;
using RestSharp;

namespace IuguClientAPI
{
    public class IuguApiClient : IIuguApiClient
    {
        private const string IUGUAPITOKEN = "IuguApiToken";
        private readonly IRestClient _httpClient;
        private string _apiToken;

        public IuguApiClient(IRestClient httpClient = default(RestClient), string baseUrl = "https://api.iugu.com/v1")
        {
            _apiToken = ConfigurationManager.AppSettings.Get(IUGUAPITOKEN);
            if (string.IsNullOrWhiteSpace(_apiToken))
                throw new ConfigurationErrorsException("IuguApiToken não está configurado no App.config ou Web.config");

            _httpClient = httpClient ?? new RestClient(new Uri(baseUrl));
        }

        public async Task<IuguClient> CreateClient(IuguClient client)
            => await PostClient(client);

        public IuguClient CreateClientSync(IuguClient client)
            => PostClient(client).Result;

        public async Task<IuguClient> UpdateClient(IuguClient client)
            => await PutClient(client);

        public IuguClient UpdateClientSync(IuguClient client)
            => PutClient(client).Result;

        public async Task<IuguClient> DeleteClient(string clientId)
        {
            var request = CreateRequest("/customers/{id}", Method.DELETE).AddUrlSegment("id", clientId);

            return (await _httpClient.ExecuteTaskAsync<IuguClient>(request)).Data;
        }

        public IuguClient DeleteClientSync(string clientId)
        {
            var request = CreateRequest("/customers/{id}", Method.DELETE).AddUrlSegment("id", clientId);

            return _httpClient.ExecuteTaskAsync<IuguClient>(request).Result.Data;
        }

        private async Task<IuguClient> PostClient(IuguClient client)
        {
            var request = CreateRequest("/customers", Method.POST).AddJsonBody(client);

            return (await _httpClient.ExecuteTaskAsync<IuguClient>(request)).Data;
        }

        private async Task<IuguClient> PutClient(IuguClient client)
        {
            var request = CreateRequest("/customers/{id}", Method.PUT).AddUrlSegment("id", client.Id).AddJsonBody(client);

            return (await _httpClient.ExecuteTaskAsync<IuguClient>(request)).Data;
        }

        private IRestRequest CreateRequest(string resource, Method method)
            => new RestRequest(resource, method).AddHeader("api_token", _apiToken);
    }
}

using System;
using System.Configuration;
using System.Threading.Tasks;
using IuguClientAPI.Interfaces;
using IuguClientAPI.Models;
using RestSharp;

namespace IuguClientAPI
{
    public class IuguApiClient : IIuguApiClient
    {
        readonly IRestClient _httpClient;
        readonly string _apiToken;
        const string IUGU_API_TOKEN = "IuguApiToken";

        public IuguApiClient(IRestClient httpClient = default(IRestClient), string baseUrl = "https://api.iugu.com/v1")
        {
            _apiToken = ConfigurationManager.AppSettings.Get(IUGU_API_TOKEN);
            if (string.IsNullOrWhiteSpace(_apiToken))
                throw new ConfigurationErrorsException("IuguApiToken não está configurado no App.config ou Web.config");

            _httpClient = httpClient ?? new RestClient(new Uri(baseUrl));
        }

        #region Client Stuff
        public async Task<IuguClient> CreateClient(IuguClient client) => await Post(client, "/customers");

        public IuguClient CreateClientSync(IuguClient client) => Post(client, "/customers").Result;

        public async Task<IuguClient> UpdateClient(IuguClient client) => await PutClient(client);

        public IuguClient UpdateClientSync(IuguClient client) => PutClient(client).Result;

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

        private async Task<T> Post<T>(T client, string url)
        {
            var request = CreateRequest(url, Method.POST).AddJsonBody(client);

            return (await _httpClient.ExecuteTaskAsync<T>(request)).Data;
        }

        private async Task<IuguClient> PutClient(IuguClient client)
        {
            var request = CreateRequest("/customers/{id}", Method.PUT).AddUrlSegment("id", client.Id).AddJsonBody(client);

            return (await _httpClient.ExecuteTaskAsync<IuguClient>(request)).Data;
        }
        #endregion

        public async Task<IuguPaymentMethod> CreatePaymentMethod(IuguPaymentMethod paymentMethod) => await Post(paymentMethod, "/payment_methods");

        protected IRestRequest CreateRequest(string resource, Method method) => new RestRequest(resource, method).AddHeader("api_token", _apiToken);
    }
}

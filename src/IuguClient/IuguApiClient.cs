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

        private async Task<IuguClient> PutClient(IuguClient client)
        {
            var request = CreateRequest("/customers/{id}", Method.PUT).AddUrlSegment("id", client.Id).AddJsonBody(client);

            return (await _httpClient.ExecuteTaskAsync<IuguClient>(request)).Data;
        }
        #endregion

        public async Task<IuguPaymentMethod> CreatePaymentMethod(IuguPaymentMethod paymentMethod) => await Post(paymentMethod, "/payment_methods");
        #region Subscription Stuff
        public async Task<IuguSubscription> CreateSubscription(IuguSubscription subscription) => await Post(subscription, "/subscriptions");

        public IuguSubscription CreateSubscriptionSync(IuguSubscription subscription) => Post(subscription, "/subscriptions").Result;

        public async Task<IuguSubscription> UpdateSubscription(IuguSubscription subscription) => await Put(subscription, subscription.Id, "/subscriptions/{id}");

        public IuguSubscription UpdateSubscriptionSync(IuguSubscription subscription) => Put(subscription, subscription.Id, "/subscriptions/{id}").Result;

        public async Task<IuguSubscription> DeleteSubscription(string subscriptionId) => await Delete<IuguSubscription>(subscriptionId, "/subscriptions/{id}");

        public IuguSubscription DeleteSubscriptionSync(string subscriptionId) => Delete<IuguSubscription>(subscriptionId, "/subscriptions/{id}").Result;

        public async Task<IuguSubscription> GetSubscription(string subscriptionId) => await Get<IuguSubscription>(subscriptionId, "/subscriptions/{id}");

        public IuguSubscription GetSubscriptionSync(string subscriptionId) => Get<IuguSubscription>(subscriptionId, "/subscriptions/{id}").Result;

        public async Task<IuguSubscription> SuspendSubscription(string subscriptionId) => await Post<IuguSubscription>(subscriptionId, "/subscriptions/{id}/suspend");

        public IuguSubscription SuspendSubscriptionSync(string subscriptionId) => Post<IuguSubscription>(subscriptionId, "/subscriptions/{id}/suspend").Result;

        public async Task<IuguSubscription> ActivateSubscription(string subscriptionId) => await Post<IuguSubscription>(subscriptionId, "/subscriptions/{id}/activate");

        public IuguSubscription ActivateSubscriptionSync(string subscriptionId) => Post<IuguSubscription>(subscriptionId, "/subscriptions/{id}/activate").Result;

        #endregion

        private IRestRequest CreateRequest(string resource, Method method) => new RestRequest(resource, method).AddHeader("api_token", _apiToken);

        private async Task<T> Get<T>(string id, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.GET).AddUrlSegment("id", id))).Data;

        private async Task<T> Post<T>(T client, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.POST).AddJsonBody(client))).Data;

        private async Task<T> Post<T>(string id, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.POST).AddUrlSegment("id", id))).Data;

        private async Task<T> Put<T>(T client, string id, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.PUT).AddUrlSegment("id", id).AddJsonBody(client))).Data;

        private async Task<T> Delete<T>(string id, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.DELETE).AddUrlSegment("id", id))).Data;
    }
}

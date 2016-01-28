using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using IuguClientAPI.Interfaces;
using RestSharp;

namespace IuguClientAPI
{
    public partial class IuguApiClient : IIuguApiClient
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

        private IRestRequest CreateRequest(string resource, Method method) => new RestRequest(resource, method).AddHeader("api_token", _apiToken);

        private async Task<T> Get<T>(string id, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.GET).AddUrlSegment("id", id))).Data;

        private async Task<T> Post<T>(T client, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.POST).AddJsonBody(client))).Data;

        private async Task<T> Post<T>(string id, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.POST).AddUrlSegment("id", id))).Data;

        private async Task<T> Post<T>(T client, IDictionary<string, string> segments, string url)
        {
            var request = CreateRequestWithParametersAndData(client, segments, url, Method.POST);
            return (await _httpClient.ExecuteTaskAsync<T>(request)).Data;
        }

        private async Task<T> Put<T>(T client, string id, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.PUT).AddUrlSegment("id", id).AddJsonBody(client))).Data;

        private async Task<T> Put<T>(string id, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.PUT).AddUrlSegment("id", id))).Data;

        private async Task<T> Put<T>(T client, IDictionary<string, string> segments, string url)
        {
            var request = CreateRequestWithParametersAndData(client, segments, url, Method.PUT);
            return (await _httpClient.ExecuteTaskAsync<T>(request)).Data;
        }

        private async Task<T> Delete<T>(string id, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.DELETE).AddUrlSegment("id", id))).Data;

        private IRestRequest CreateRequestWithParametersAndData<T>(T data, IDictionary<string, string> segments,
            string url, Method method)
        {
            var request = CreateRequest(url, method).AddJsonBody(data);

            foreach (var segment in segments)
                request.AddUrlSegment(segment.Key, segment.Value);

            return request;
        }
    }
}

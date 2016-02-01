using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IuguClientAPI.Exceptions;
using IuguClientAPI.Interfaces;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace IuguClientAPI
{
    public partial class IuguApiClient : IIuguApiClient
    {
        readonly IRestClient _httpClient;
        private readonly HttpBasicAuthenticator _httpBasicAuthenticator;
        const string IUGU_API_TOKEN = "IuguApiToken";

        public IuguApiClient(IRestClient httpClient = default(IRestClient), string baseUrl = "https://api.iugu.com/v1")
        {
            var apiToken = ConfigurationManager.AppSettings.Get(IUGU_API_TOKEN);
            if (string.IsNullOrWhiteSpace(apiToken))
                throw new ConfigurationErrorsException("IuguApiToken não está configurado no App.config ou Web.config");

            _httpBasicAuthenticator = new HttpBasicAuthenticator(apiToken, "");
            _httpClient = httpClient ?? new RestClient(new Uri(baseUrl));
            _httpClient.AddHandler("application/json", NewtonsoftJsonSerializer.Instance);
        }

        private IRestRequest CreateRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            _httpBasicAuthenticator.Authenticate(_httpClient, request);
            request.JsonSerializer = NewtonsoftJsonSerializer.Instance;
            return request;
        }

        private async Task<T> Get<T>(string id, string url)
            => (await _httpClient.ExecuteTaskAsync<T>(CreateRequest(url, Method.GET).AddUrlSegment("id", id))).Data;

        private async Task<T> Post<T>(T client, string url)
        {
            var request = CreateRequest(url, Method.POST).AddJsonBody(client);
            var restResponse = await _httpClient.ExecuteTaskAsync<T>(request);
            return restResponse.Data;
        }

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

        private T GetSync<T>(string id, string url)
        {
            var request = CreateRequest(url, Method.GET).AddUrlSegment("id", id);
            var response = _httpClient.Execute(request);
            return NewtonsoftJsonSerializer.Instance.Deserialize<T>(response);
        }

        private T PostSync<T>(T client, string url)
        {
            var request = CreateRequest(url, Method.POST).AddJsonBody(client);
            return ExecuteRequest<T>(request);
        }

        private T PostSync<T>(string id, string url)
        {
            var request = CreateRequest(url, Method.POST).AddUrlSegment("id", id);
            var restResponse = _httpClient.Execute(request);
            return NewtonsoftJsonSerializer.Instance.Deserialize<T>(restResponse);
        }

        private T PostSync<T>(T client, IDictionary<string, string> segments, string url)
        {
            var request = CreateRequestWithParametersAndData(client, segments, url, Method.POST);
            var restResponse = _httpClient.Execute(request);
            return NewtonsoftJsonSerializer.Instance.Deserialize<T>(restResponse);
        }

        private T PutSync<T>(T client, string id, string url)
        {
            var request = CreateRequest(url, Method.PUT).AddUrlSegment("id", id).AddJsonBody(client);
            var restResponse = _httpClient.Execute(request);
            return NewtonsoftJsonSerializer.Instance.Deserialize<T>(restResponse);
        }

        private T PutSync<T>(string id, string url)
        {
            var request = CreateRequest(url, Method.PUT).AddUrlSegment("id", id);
            var restResponse = _httpClient.Execute(request);
            return NewtonsoftJsonSerializer.Instance.Deserialize<T>(restResponse);
        }

        private T PutSync<T>(T client, IDictionary<string, string> segments, string url)
        {
            var request = CreateRequestWithParametersAndData(client, segments, url, Method.PUT);
            var restResponse = _httpClient.Execute(request);
            return NewtonsoftJsonSerializer.Instance.Deserialize<T>(restResponse);
        }

        private T DeleteSync<T>(string id, string url)
        {
            var request = CreateRequest(url, Method.DELETE).AddUrlSegment("id", id);
            var restResponse = _httpClient.Execute(request);
            return NewtonsoftJsonSerializer.Instance.Deserialize<T>(restResponse);
        }

        private T ExecuteRequest<T>(IRestRequest request)
        {
            var response = _httpClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return NewtonsoftJsonSerializer.Instance.Deserialize<T>(response);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new IuguUnauthorizedException();

            var errors = JToken.Parse(response.Content)["errors"].Value<JObject>();
            throw new IuguErrorException(errors.Properties().ToDictionary(p => p.Name, p => errors[p.Name].ToObject<string[]>()));
        }

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

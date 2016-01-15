using System;
using System.Threading;
using System.Threading.Tasks;
using IuguClientAPI.Models;
using Newtonsoft.Json;
using RestSharp;

namespace IuguClientAPI
{
    public class IuguApiClient : IIuguApiClient
    {
        private readonly RestClient _httpClient;

        public IuguApiClient(RestClient httpClient = default(RestClient), string baseUrl = "https://api.iugu.com/v1")
        {
            _httpClient = httpClient ?? new RestClient { BaseUrl = new Uri(baseUrl) };
        }

        public async Task<IuguClient> CreateClient(IuguClient client)
        {
            var jsonClient = await PostClient(client);

            return JsonConvert.DeserializeObject<IuguClient>(jsonClient);
        }

        private async Task<string> PostClient(IuguClient client)
        {
            var request = GetRestRequest("/customers", Method.POST);
            request.AddBody(client);

            var response = await _httpClient.ExecuteTaskAsync<string>(request, CancellationToken.None);
            var jsonClient = await Task.Run(() => JsonConvert.DeserializeObject(response.Content));
            return jsonClient;
        }

        public IuguClient CreateClientSync(IuguClient client)
        {
            var result = PostClient(client).Result;
            return JsonConvert.DeserializeObject<IuguClient>(result);
        }

        private RestRequest GetRestRequest(string resource, Method method)
        {
            return new RestRequest(resource, method) { RequestFormat = DataFormat.Json };
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}

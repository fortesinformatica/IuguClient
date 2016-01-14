using System;
using System.Net.Http;
using System.Threading.Tasks;
using IuguClientAPI.Models;
using Newtonsoft.Json;

namespace IuguClientAPI
{
    public class IuguApiClient : IIuguApiClient
    {
        private readonly HttpClient _httpClient;

        public IuguApiClient(HttpClient httpClient = default(HttpClient), string baseUrl = "https://api.iugu.com/v1")
        {
            _httpClient = httpClient ?? new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<IuguClient> CreateClient(IuguClient client)
        {
            var jsonClient = await PostClient(client);

            return JsonConvert.DeserializeObject<IuguClient>(jsonClient);
        }

        private async Task<string> PostClient(IuguClient client)
        {
            var response = await _httpClient.PostAsJsonAsync("/customers2", client);
            var jsonClient = await response.Content.ReadAsStringAsync();
            return jsonClient;
        }

        public IuguClient CreateClientSync(IuguClient client)
        {
            var result = PostClient(client).Result;
            return JsonConvert.DeserializeObject<IuguClient>(result);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}

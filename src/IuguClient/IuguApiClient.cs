using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using IuguClientAPI.Models;
using Newtonsoft.Json;

namespace IuguClientAPI
{
    public class IuguApiClient : IIuguApiClient
    {
        private const string IUGUAPITOKEN = "IuguApiToken";
        private readonly HttpClient _httpClient;
        private string _baseUrl;

        public IuguApiClient(HttpClient httpClient = default(HttpClient), string baseUrl = "https://api.iugu.com/v1")
        {
            _baseUrl = baseUrl;
            var apiToken = ConfigurationManager.AppSettings.Get(IUGUAPITOKEN);
            if (string.IsNullOrWhiteSpace(apiToken))
                throw new ConfigurationErrorsException("IuguApiToken não está configurado no App.config ou Web.config");
           
            _httpClient = httpClient ?? new HttpClient { BaseAddress = new Uri(baseUrl) };
            _httpClient.DefaultRequestHeaders.Add("api_token", apiToken);
        }

        public async Task<IuguClient> CreateClient(IuguClient client)
            => JsonConvert.DeserializeObject<IuguClient>(await PostClient(client));

        public IuguClient CreateClientSync(IuguClient client)
            => JsonConvert.DeserializeObject<IuguClient>(PostClient(client).Result);

        public async Task<IuguClient> UpdateClient(IuguClient client)
            => JsonConvert.DeserializeObject<IuguClient>(await PutClient(client));

        public IuguClient UpdateClientSync(IuguClient client)
            => JsonConvert.DeserializeObject<IuguClient>(PutClient(client).Result);

        public async Task<IuguClient> DeleteClient(string clientId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/customers/{clientId}");
            return JsonConvert.DeserializeObject<IuguClient>(await response.Content.ReadAsStringAsync());
        }

        public IuguClient DeleteClientSync(string clientId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        private async Task<string> PostClient(IuguClient client)
        {
            var response = await _httpClient.PostAsJsonAsync("/customers", client);
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> PutClient(IuguClient client)
        {
            var response = await _httpClient.PutAsJsonAsync($"/customers/{client.Id}", client);
            return await response.Content.ReadAsStringAsync();
        }
    }
}

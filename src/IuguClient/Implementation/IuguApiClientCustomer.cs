using System.Threading.Tasks;
using IuguClientAPI.Models;
using RestSharp;

namespace IuguClientAPI
{
    public partial class IuguApiClient
    {
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

    }
}

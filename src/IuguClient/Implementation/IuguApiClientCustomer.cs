using System.Threading.Tasks;
using IuguClientAPI.Models;
using RestSharp;

namespace IuguClientAPI
{
    public partial class IuguApiClient
    {
        #region Client Stuff
        public async Task<IuguCustomer> CreateClient(IuguCustomer customer) => await Post(customer, "/customers");

        public IuguCustomer CreateClientSync(IuguCustomer customer) => Post(customer, "/customers").Result;

        public async Task<IuguCustomer> UpdateClient(IuguCustomer customer) => await PutClient(customer);

        public IuguCustomer UpdateClientSync(IuguCustomer customer) => PutClient(customer).Result;

        public async Task<IuguCustomer> DeleteClient(string clientId)
        {
            var request = CreateRequest("/customers/{id}", Method.DELETE).AddUrlSegment("id", clientId);

            return (await _httpClient.ExecuteTaskAsync<IuguCustomer>(request)).Data;
        }

        public IuguCustomer DeleteClientSync(string clientId)
        {
            var request = CreateRequest("/customers/{id}", Method.DELETE).AddUrlSegment("id", clientId);

            return _httpClient.ExecuteTaskAsync<IuguCustomer>(request).Result.Data;
        }

        private async Task<IuguCustomer> PutClient(IuguCustomer customer)
        {
            var request = CreateRequest("/customers/{id}", Method.PUT).AddUrlSegment("id", customer.Id).AddJsonBody(customer);

            return (await _httpClient.ExecuteTaskAsync<IuguCustomer>(request)).Data;
        }
        #endregion

    }
}

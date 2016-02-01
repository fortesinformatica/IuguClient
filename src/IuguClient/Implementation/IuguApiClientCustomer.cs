using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI
{
    public partial class IuguApiClient
    {
        public async Task<IuguCustomer> CreateClient(IuguCustomer customer) => await Post(customer, "/customers");

        public IuguCustomer CreateClientSync(IuguCustomer customer) => PostSync(customer, "/customers");

        public async Task<IuguCustomer> UpdateClient(IuguCustomer customer) => await Put(customer, customer.Id, "/customers/{id}");

        public IuguCustomer UpdateClientSync(IuguCustomer customer) => PutSync(customer, customer.Id, "/customers/{id}");

        public async Task<IuguCustomer> DeleteClient(string clientId) => await Delete<IuguCustomer>(clientId, "/customers/{id}");

        public IuguCustomer DeleteClientSync(string clientId) => DeleteSync<IuguCustomer>(clientId, "/customers/{id}");
    }
}

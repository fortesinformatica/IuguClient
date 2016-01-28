using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI.Interfaces
{
    public interface IIuguApiCustomerClient
    {
        Task<IuguCustomer> CreateClient(IuguCustomer customer);
        IuguCustomer CreateClientSync(IuguCustomer customer);
        Task<IuguCustomer> UpdateClient(IuguCustomer customer);
        IuguCustomer UpdateClientSync(IuguCustomer customer);
        Task<IuguCustomer> DeleteClient(string clientId);
        IuguCustomer DeleteClientSync(string clientId);
    }
}
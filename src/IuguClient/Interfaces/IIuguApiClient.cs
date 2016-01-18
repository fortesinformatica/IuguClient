using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI.Interfaces
{
    public interface IIuguApiClient
    {
        Task<IuguClient> CreateClient(IuguClient client);
        IuguClient CreateClientSync(IuguClient client);
        Task<IuguClient> UpdateClient(IuguClient client);
        IuguClient UpdateClientSync(IuguClient client);
        Task<IuguClient> DeleteClient(string clientId);
        IuguClient DeleteClientSync(string clientId);

        Task<IuguPaymentMethod> CreatePaymentMethod(IuguPaymentMethod paymentMethod);
    }
}
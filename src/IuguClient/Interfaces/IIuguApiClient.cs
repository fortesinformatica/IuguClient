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

        Task<IuguSubscription> CreateSubscription(IuguSubscription subscription);
        IuguSubscription CreateSubscriptionSync(IuguSubscription subscription);
        Task<IuguSubscription> UpdateSubscription(IuguSubscription subscription);
        IuguSubscription UpdateSubscriptionSync(IuguSubscription subscription);
        Task<IuguSubscription> DeleteSubscription(string subscriptionId);
        IuguSubscription DeleteSubscriptionSync(string subscriptionId);
        Task<IuguSubscription> GetSubscription(string subscriptionId);
        IuguSubscription GetSubscriptionSync(string subscriptionId);
        Task<IuguSubscription> SuspendSubscription(string subscriptionId);
        IuguSubscription SuspendSubscriptionSync(string subscriptionId);
        Task<IuguSubscription> ActivateSubscription(string subscriptionId);
        IuguSubscription ActivateSubscriptionSync(string subscriptionId);

    }
}
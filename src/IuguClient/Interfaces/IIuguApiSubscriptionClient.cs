using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI.Interfaces
{
    public interface IIuguApiSubscriptionClient
    {
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
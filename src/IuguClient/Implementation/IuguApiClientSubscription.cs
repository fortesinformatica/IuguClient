using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI
{
    public partial class IuguApiClient
    {
        #region Subscription Stuff
        public async Task<IuguSubscription> CreateSubscription(IuguSubscription subscription) => await Post(subscription, "/subscriptions");

        public IuguSubscription CreateSubscriptionSync(IuguSubscription subscription) => Post(subscription, "/subscriptions").Result;

        public async Task<IuguSubscription> UpdateSubscription(IuguSubscription subscription) => await Put(subscription, subscription.Id, "/subscriptions/{id}");

        public IuguSubscription UpdateSubscriptionSync(IuguSubscription subscription) => Put(subscription, subscription.Id, "/subscriptions/{id}").Result;

        public async Task<IuguSubscription> DeleteSubscription(string subscriptionId) => await Delete<IuguSubscription>(subscriptionId, "/subscriptions/{id}");

        public IuguSubscription DeleteSubscriptionSync(string subscriptionId) => Delete<IuguSubscription>(subscriptionId, "/subscriptions/{id}").Result;

        public async Task<IuguSubscription> GetSubscription(string subscriptionId) => await Get<IuguSubscription>(subscriptionId, "/subscriptions/{id}");

        public IuguSubscription GetSubscriptionSync(string subscriptionId) => Get<IuguSubscription>(subscriptionId, "/subscriptions/{id}").Result;

        public async Task<IuguSubscription> SuspendSubscription(string subscriptionId) => await Post<IuguSubscription>(subscriptionId, "/subscriptions/{id}/suspend");

        public IuguSubscription SuspendSubscriptionSync(string subscriptionId) => Post<IuguSubscription>(subscriptionId, "/subscriptions/{id}/suspend").Result;

        public async Task<IuguSubscription> ActivateSubscription(string subscriptionId) => await Post<IuguSubscription>(subscriptionId, "/subscriptions/{id}/activate");

        public IuguSubscription ActivateSubscriptionSync(string subscriptionId) => Post<IuguSubscription>(subscriptionId, "/subscriptions/{id}/activate").Result;

        #endregion

    }
}

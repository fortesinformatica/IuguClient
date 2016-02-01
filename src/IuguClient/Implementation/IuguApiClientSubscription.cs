using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI
{
    public partial class IuguApiClient
    {
        #region Subscription Stuff
        public async Task<IuguSubscription> CreateSubscription(IuguSubscription subscription) => await Post(subscription, "/subscriptions");

        public IuguSubscription CreateSubscriptionSync(IuguSubscription subscription) => PostSync(subscription, "/subscriptions");

        public async Task<IuguSubscription> UpdateSubscription(IuguSubscription subscription) => await Put(subscription, subscription.Id, "/subscriptions/{id}");

        public IuguSubscription UpdateSubscriptionSync(IuguSubscription subscription) => PutSync(subscription, subscription.Id, "/subscriptions/{id}");

        public async Task<IuguSubscription> DeleteSubscription(string subscriptionId) => await Delete<IuguSubscription>(subscriptionId, "/subscriptions/{id}");

        public IuguSubscription DeleteSubscriptionSync(string subscriptionId) => DeleteSync<IuguSubscription>(subscriptionId, "/subscriptions/{id}");

        public async Task<IuguSubscription> GetSubscription(string subscriptionId) => await Get<IuguSubscription>(subscriptionId, "/subscriptions/{id}");

        public IuguSubscription GetSubscriptionSync(string subscriptionId) => GetSync<IuguSubscription>(subscriptionId, "/subscriptions/{id}");

        public async Task<IuguSubscription> SuspendSubscription(string subscriptionId) => await Post<IuguSubscription>(subscriptionId, "/subscriptions/{id}/suspend");

        public IuguSubscription SuspendSubscriptionSync(string subscriptionId) => PostSync<IuguSubscription>(subscriptionId, "/subscriptions/{id}/suspend");

        public async Task<IuguSubscription> ActivateSubscription(string subscriptionId) => await Post<IuguSubscription>(subscriptionId, "/subscriptions/{id}/activate");

        public IuguSubscription ActivateSubscriptionSync(string subscriptionId) => PostSync<IuguSubscription>(subscriptionId, "/subscriptions/{id}/activate");

        #endregion
    }
}

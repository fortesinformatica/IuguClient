using System;
using IuguClientAPI.Interfaces;
using IuguClientAPI.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace IuguClientAPI.Tests
{
    [Binding]
    public class SubscriptionCRUDSteps : BaseStep<IuguSubscription>
    {
        private readonly IIuguApiSubscriptionClient _sut;
        private IuguSubscription _subscriptionAdded;
        private IuguSubscription _subscriptionUpdated;
        private IuguSubscription _subscriptionDeleted;
        private string _subscriptionId;
        private IuguSubscription _subscription;
        private readonly IuguSubscription _subscriptionToDelete;
        private readonly IuguSubscription _subscriptionToAdd;
        private readonly IuguSubscription _subscriptionToUpdate;

        public SubscriptionCRUDSteps()
        {
            _sut = new IuguApiClient(CrudStepsBase.RestClient);

            _subscriptionToAdd = new IuguSubscription("idCliente");
            _subscriptionToUpdate = new IuguSubscription("1", false, "", null, null, null, null, null, null, DateTime.Today, DateTime.Today, "", "", null, null, null, "", "", "", "", true, null, 0, null, null, null, null, null);
            _subscriptionToDelete = new IuguSubscription("1", false, "", null, null, null, null, null, null, DateTime.Today, DateTime.Today, "", "", null, null, null, "", "", "", "", true, null, 0, null, null, null, null, null);
        }

        [Given(@"a Subscription")]
        public void GivenASubscription()
        {
            _subscription = new IuguSubscription("1", false, "", null, null, null, null, null, null, DateTime.Today, DateTime.Today, "", "", null, null, null, "", "", "", "", true, null, 0, null, null, null, null, null);
        }

        [Given(@"a id of the subscription")]
        public void GivenAIdOfTheSubscription()
        {
            _subscriptionId = "1";
        }

        [When(@"I request the subscription to be added")]
        public void WhenIRequestTheSubscriptionToBeAdded() => _subscriptionAdded = CallMethodAndMockResponse(() => _sut.CreateSubscription(_subscription).Result, _subscription);

        [When(@"I request the subscription to be added sync")]
        public void WhenIRequestTheSubscriptionToBeAddedSync() => _subscriptionAdded = CallMethodAndMockResponse(() => _sut.CreateSubscriptionSync(_subscription),
            _subscription);

        [When(@"I request the subscription to be edited")]
        public void WhenIRequestTheSubscriptionToBeEdited() => _subscriptionUpdated = CallMethodAndMockResponse(() => _sut.UpdateSubscription(_subscriptionToUpdate).Result, _subscriptionToUpdate);

        [When(@"I request the subscription to be edited sync")]
        public void WhenIRequestTheSubscriptionToBeEditedSync() => _subscriptionUpdated = CallMethodAndMockResponse(() => _sut.UpdateSubscriptionSync(_subscriptionToUpdate), _subscriptionToUpdate);

        [When(@"I request the subscription to be removed")]
        public void WhenIRequestTheSubscriptionToBeRemoved() => _subscriptionDeleted = CallMethodAndMockResponse(() => _sut.DeleteSubscription(_subscriptionId).Result, _subscriptionToDelete);

        [When(@"I request the subscription to be removed sync")]
        public void WhenIRequestTheSubscriptionToBeRemovedSync() => _subscriptionDeleted = CallMethodAndMockResponse(() => _sut.DeleteSubscriptionSync(_subscriptionId), _subscriptionToDelete);

        [When(@"I request the subscription to be got")]
        public void WhenIRequestTheSubscriptionToBeGot() => _subscriptionUpdated = CallMethodAndMockResponse(() => _sut.GetSubscription(_subscriptionId).Result, _subscriptionToUpdate);

        [When(@"I request the subscription to be got sync")]
        public void WhenIRequestTheSubscriptionToBeGotSync() => _subscriptionUpdated = CallMethodAndMockResponse(() => _sut.GetSubscriptionSync(_subscriptionId), _subscriptionToUpdate);

        [When(@"I request the subscription to be suspended")]
        public void WhenIRequestTheSubscriptionToBeSuspended() => _subscriptionUpdated = CallMethodAndMockResponse(() => _sut.SuspendSubscription(_subscriptionId).Result, _subscriptionToUpdate);

        [When(@"I request the subscription to be suspended sync")]
        public void WhenIRequestTheSubscriptionToBeSuspendedSync() => _subscriptionUpdated = CallMethodAndMockResponse(() => _sut.SuspendSubscriptionSync(_subscriptionId), _subscriptionToUpdate);

        [When(@"I request the subscription to be activated")]
        public void WhenIRequestTheSubscriptionToBeActivated() => _subscriptionUpdated = CallMethodAndMockResponse(() => _sut.ActivateSubscription(_subscriptionId).Result, _subscriptionToUpdate);

        [When(@"I request the subscription to be activated sync")]
        public void WhenIRequestTheSubscriptionToBeActivatedSync() => _subscriptionUpdated = CallMethodAndMockResponse(() => _sut.ActivateSubscriptionSync(_subscriptionId), _subscriptionToUpdate);

        [Then(@"should return a subscription got")]
        public void ThenShouldReturnASubscriptionGot() => Assert.IsNotNull(_subscriptionUpdated);

        [Then(@"should return a Subscription created")]
        public void ThenShouldReturnASubscriptionCreated() => Assert.IsNotNull(_subscriptionAdded);

        [Then(@"should return a Subscription edited")]
        public void ThenShouldReturnASubscriptionEdited() => Assert.IsNotNull(_subscriptionUpdated);

        [Then(@"should return a subscription removed")]
        public void ThenShouldReturnASubscriptionRemoved() => Assert.IsNotNull(_subscriptionDeleted);
    }
}

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IuguClientAPI.Interfaces;
using IuguClientAPI.Models;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace IuguClientAPI.Tests
{
    [Binding]
    public class SubscriptionCRUDSteps
    {
        private readonly IRestClient _restClient;
        private readonly IIuguApiSubscriptionClient _sut;
        private readonly IRestResponse<IuguSubscription> _restResponse;
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
            _restClient = CrudStepsBase.RestClient = Substitute.For<IRestClient>();
            CrudStepsBase.Asserter = MatchRequest;
            _sut = new IuguApiClient(_restClient);
            _restResponse = Substitute.For<IRestResponse<IuguSubscription>>();

            _subscriptionToAdd = new IuguSubscription("idCliente");
            _subscriptionToUpdate = new IuguSubscription("1", false, "", null, null, null, null, null, null, DateTime.Today, DateTime.Today, "", "", null, null, null, "", "", "", "", true, null, 0, null, null, null, null, null);
            _subscriptionToDelete = new IuguSubscription("1", false, "", null, null, null, null, null, null, DateTime.Today, DateTime.Today, "", "", null, null, null, "", "", "", "", true, null, 0, null, null, null, null, null);
        }

        private Task<IRestResponse<IuguSubscription>> MatchRequest(Expression<Predicate<IRestRequest>> exp)
            => _restClient.Received().ExecuteTaskAsync<IuguSubscription>(Arg.Is(exp));


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
        public void WhenIRequestTheSubscriptionToBeAdded()
        {
            _restResponse.Data.Returns(_subscriptionToAdd);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionAdded = _sut.CreateSubscription(_subscription).Result;
        }

        [When(@"I request the subscription to be added sync")]
        public void WhenIRequestTheSubscriptionToBeAddedSync()
        {
            _restResponse.Data.Returns(_subscriptionToAdd);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionAdded = _sut.CreateSubscriptionSync(_subscription);
        }

        [When(@"I request the subscription to be edited")]
        public void WhenIRequestTheSubscriptionToBeEdited()
        {
            _restResponse.Data.Returns(_subscriptionToUpdate);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionUpdated = _sut.UpdateSubscription(_subscription).Result;
        }

        [When(@"I request the subscription to be edited sync")]
        public void WhenIRequestTheSubscriptionToBeEditedSync()
        {
            _restResponse.Data.Returns(_subscriptionToUpdate);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionUpdated = _sut.UpdateSubscriptionSync(_subscription);
        }

        [When(@"I request the subscription to be removed")]
        public void WhenIRequestTheSubscriptionToBeRemoved()
        {
            _restResponse.Data.Returns(_subscriptionToDelete);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionDeleted = _sut.DeleteSubscription(_subscriptionId).Result;
        }

        [When(@"I request the subscription to be removed sync")]
        public void WhenIRequestTheSubscriptionToBeRemovedSync()
        {
            _restResponse.Data.Returns(_subscriptionToDelete);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionDeleted = _sut.DeleteSubscriptionSync(_subscriptionId);
        }

        [When(@"I request the subscription to be got")]
        public void WhenIRequestTheSubscriptionToBeGot()
        {
            _restResponse.Data.Returns(_subscriptionToUpdate);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionUpdated = _sut.GetSubscription(_subscriptionId).Result;
        }

        [When(@"I request the subscription to be got sync")]
        public void WhenIRequestTheSubscriptionToBeGotSync()
        {
            _restResponse.Data.Returns(_subscriptionToUpdate);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionUpdated = _sut.GetSubscriptionSync(_subscriptionId);
        }

        [When(@"I request the subscription to be suspended")]
        public void WhenIRequestTheSubscriptionToBeSuspended()
        {
            _restResponse.Data.Returns(_subscriptionToUpdate);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionUpdated = _sut.SuspendSubscription(_subscriptionId).Result;
        }

        [When(@"I request the subscription to be suspended sync")]
        public void WhenIRequestTheSubscriptionToBeSuspendedSync()
        {
            _restResponse.Data.Returns(_subscriptionToUpdate);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionUpdated = _sut.SuspendSubscriptionSync(_subscriptionId);
        }

        [When(@"I request the subscription to be activated")]
        public void WhenIRequestTheSubscriptionToBeActivated()
        {
            _restResponse.Data.Returns(_subscriptionToUpdate);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionUpdated = _sut.ActivateSubscription(_subscriptionId).Result;
        }

        [When(@"I request the subscription to be activated sync")]
        public void WhenIRequestTheSubscriptionToBeActivatedSync()
        {
            _restResponse.Data.Returns(_subscriptionToUpdate);
            _restClient.ExecuteTaskAsync<IuguSubscription>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _subscriptionUpdated = _sut.ActivateSubscriptionSync(_subscriptionId);
        }

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

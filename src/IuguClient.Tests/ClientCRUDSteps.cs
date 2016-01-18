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
    public class ClientCRUDSteps
    {
        private readonly IIuguApiClient _sut;
        private IuguClient _client;
        private IuguClient _createdClient;
        private IuguClient _editedClient;
        private string _clientId;
        private IuguClient _deletedClient;
        private readonly IRestResponse<IuguClient> _restResponse;
        private readonly IRestClient _restClient;

        public ClientCRUDSteps()
        {
            _restClient = CrudStepsBase.RestClient = Substitute.For<IRestClient>();
            CrudStepsBase.Asserter = MatchRequest;
            _sut = new IuguApiClient(_restClient);
            _restResponse = Substitute.For<IRestResponse<IuguClient>>();
            _createdClient = new IuguClient("1", email: "teste@mail.com");
            _editedClient = new IuguClient("1", email: "teste@mail.com", name: "Fulano");
            _deletedClient = new IuguClient("1", email: "teste@mail.com", name: "Fulano");
        }

        private Task<IRestResponse<IuguClient>> MatchRequest(Expression<Predicate<IRestRequest>> exp)
            => _restClient.Received().ExecuteTaskAsync<IuguClient>(Arg.Is(exp));

        [Given(@"a Client")]
        public void GivenAClient()
        {
            _client = new IuguClient("1", email: "teste@mail.com");
        }

        [Given(@"a id of the client")]
        public void GivenAIdOfTheClient()
        {
            _clientId = "1";
        }

        [When(@"I request the client to be removed")]
        public void WhenIRequestTheClientToBeRemoved()
        {
            _restResponse.Data.Returns(_deletedClient);
            _restClient.ExecuteTaskAsync<IuguClient>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _deletedClient = _sut.DeleteClient(_clientId).Result;
        }

        [When(@"I request the client to be removed sync")]
        public void WhenIRequestTheClientToBeRemovedSync()
        {
            _restResponse.Data.Returns(_deletedClient);
            _restClient.ExecuteTaskAsync<IuguClient>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _deletedClient = _sut.DeleteClientSync(_clientId);
        }

        [When(@"I request the client to be added")]
        public void WhenIRequestTheClientToBeAdded()
        {
            _restResponse.Data.Returns(_createdClient);
            _restClient.ExecuteTaskAsync<IuguClient>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _createdClient = _sut.CreateClient(_client).Result;
        }

        [When(@"I request the client to be added sync")]
        public void WhenIRequestTheClientToBeAddedSync()
        {
            _restResponse.Data.Returns(_createdClient);
            _restClient.ExecuteTaskAsync<IuguClient>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _createdClient = _sut.CreateClientSync(_client);
        }

        [When(@"I request the client to be edited")]
        public void WhenIRequestTheClientToBeEdited()
        {
            _restResponse.Data.Returns(_editedClient);
            _restClient.ExecuteTaskAsync<IuguClient>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _editedClient = _sut.UpdateClient(new IuguClient("1", email: "teste@mail.com")).Result;
        }

        [When(@"I request the client to be edited sync")]
        public void WhenIRequestTheClientToBeEditedSync()
        {
            _restResponse.Data.Returns(_editedClient);
            _restClient.ExecuteTaskAsync<IuguClient>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _editedClient = _sut.UpdateClientSync(_client);
        }

        [Then(@"should return a Client created")]
        public void ThenShouldReturnAClientCreated() => Assert.IsNotNull(_createdClient);

        [Then(@"should return a Client edited")]
        public void ThenShouldReturnAClientEdited() => Assert.AreEqual("Fulano", _editedClient.Name);

        [Then(@"should return a client removed")]
        public void ThenShouldReturnAClientRemoved() => Assert.IsNotNull(_deletedClient);
    }
}

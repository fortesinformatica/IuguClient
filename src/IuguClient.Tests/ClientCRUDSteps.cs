using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace IuguClientAPI.Tests
{
    [Binding]
    public class ClientCRUDSteps
    {
        private IRestClient _httpClient;
        private IIuguApiClient _sut;
        private Models.IuguClient _client;
        private Models.IuguClient _createdClient;
        private Models.IuguClient _editedClient;
        private Models.IuguClient _clientToBeEdited;
        private string _clientId;
        private Models.IuguClient _deletedClient;
        private IRestResponse<Models.IuguClient> _restResponse;

        [BeforeScenario]
        public void Setup()
        {
            _httpClient = Substitute.For<IRestClient>();
            _sut = new IuguApiClient(_httpClient);
            _restResponse = Substitute.For<IRestResponse<Models.IuguClient>>();
            _createdClient = new Models.IuguClient("1", email: "teste@mail.com");
            _editedClient = new Models.IuguClient("1", email: "teste@mail.com", name: "Fulano");
            _deletedClient = new Models.IuguClient("1", email: "teste@mail.com", name: "Fulano");
        }

        [Given(@"a Client")]
        public void GivenAClient()
        {
            _client = new Models.IuguClient("1", email: "teste@mail.com");
            _clientToBeEdited = new Models.IuguClient("1", "teste@teste.com", name: "Fulano");
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
            _httpClient.ExecuteTaskAsync<Models.IuguClient>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _deletedClient = _sut.DeleteClient(_clientId).Result;
        }

        [When(@"I request the client to be added")]
        public void WhenIRequestTheClientToBeAdded()
        {
            _restResponse.Data.Returns(_createdClient);
            _httpClient.ExecuteTaskAsync<Models.IuguClient>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _createdClient = _sut.CreateClient(_client).Result;
        }

        [When(@"I request the client to be added sync")]
        public void WhenIRequestTheClientToBeAddedSync()
        {
            _restResponse.Data.Returns(_createdClient);
            _httpClient.ExecuteTaskAsync<Models.IuguClient>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _createdClient = _sut.CreateClientSync(_client);
        }

        [When(@"I request the client to be edited")]
        public void WhenIRequestTheClientToBeEdited()
        {
            _restResponse.Data.Returns(_editedClient);
            _httpClient.ExecuteTaskAsync<Models.IuguClient>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _editedClient = _sut.UpdateClient(new Models.IuguClient("1", email: "teste@mail.com")).Result;
        }

        [When(@"I request the client to be edited sync")]
        public void WhenIRequestTheClientToBeEditedSync()
        {
            _restResponse.Data.Returns(_editedClient);
            _httpClient.ExecuteTaskAsync<Models.IuguClient>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _editedClient = _sut.UpdateClientSync(_client);
        }

        [Then(@"the request should be a POST")]
        public Task ThenTheRequestShouldBeAPOST()
            => AssertThatRequestMatches(h => h.Method == Method.POST);

        [Then(@"should send Json object into the body")]
        public Task ThenShouldSendJsonObjectIntoTheBody()
            => AssertThatRequestMatches(h => h.RequestFormat == DataFormat.Json);

        [Then(@"the url should end with ""(.*)""")]
        public void ThenTheUrlShouldEndWith(string uri)
            => AssertThatRequestMatches(h => h.Resource == uri);

        [Then(@"the url should end with ""(.*)"" with id value equals to (.*)")]
        public void ThenTheUrlShouldEndWithWithIdValueEqualsTo(string uri, int id)
            => AssertThatRequestMatches(h => h.Resource == uri && h.Parameters.Any(p => p.Type == ParameterType.UrlSegment && (string)p.Value == id.ToString()));

        [Then(@"should return a Client created")]
        public void ThenShouldReturnAClientCreated() => Assert.IsNotNull(_createdClient);

        [Then(@"the request should be a PUT")]
        public void ThenTheRequestShouldBeAPUT() => AssertThatRequestMatches(h => h.Method == Method.PUT);

        [Then(@"should return a Client edited")]
        public void ThenShouldReturnAClientEdited() => Assert.AreEqual("Fulano", _editedClient.Name);

        [Then(@"the request should be a DELETE")]
        public void ThenTheRequestShouldBeADELETE()
            => AssertThatRequestMatches(h => h.Method == Method.DELETE);

        [Then(@"should send Api Token into the header")]
        public void ThenShouldSendApiTokenIntoTheHeader()
            => AssertThatRequestMatches(h => h.Parameters.Any(x => x.Type == ParameterType.HttpHeader && x.Name == "api_token"));

        [Then(@"should return a client removed")]
        public void ThenShouldReturnAClientRemoved() => Assert.IsNotNull(_deletedClient);


        private Task<IRestResponse<Models.IuguClient>> AssertThatRequestMatches(Expression<Predicate<IRestRequest>> expression)
            => _httpClient.Received().ExecuteTaskAsync<Models.IuguClient>(Arg.Is(expression));
    }
}

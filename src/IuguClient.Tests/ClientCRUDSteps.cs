using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace IuguClientAPI.Tests
{
    [Binding]
    public class ClientCRUDSteps
    {
        private HttpClient _httpClient;
        private IIuguApiClient _sut;
        private Models.IuguClient _client;
        private Models.IuguClient _createdClient;
        private Models.IuguClient _editedClient;
        private Models.IuguClient _clientToBeEdited;
        private string _clientId;
        private Models.IuguClient deletedClient;

        [BeforeScenario]
        public void Setup()
        {
            _httpClient = Substitute.ForPartsOf<HttpClient>();
            _httpClient.DefaultRequestHeaders.Add("api_token", "sdad");
            _sut = new IuguApiClient(_httpClient);

        }

        [Given(@"a Client")]
        public void GivenAClient()
        {
            _client = new Models.IuguClient("1", email: "teste@mail.com");
            _clientToBeEdited = new Models.IuguClient("1", "teste@teste.com", name: "Fulano");
        }

        [When(@"I request the client to be added")]
        public async Task WhenIRequestTheClientToBeAdded()
        {
            _httpClient.PostAsJsonAsync("/customers", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(_client)) });
            _createdClient = _sut.CreateClient(_client).Result;
        }

        [When(@"I request the client to be added sync")]
        public void WhenIRequestTheClientToBeAddedSync()
        {
            _httpClient.PostAsJsonAsync("/customers", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(_client)) });
            _createdClient = _sut.CreateClientSync(_client);
        }

        [When(@"I request the client to be edited")]
        public void WhenIRequestTheClientToBeEdited()
        {
            _httpClient.PutAsJsonAsync("/customers/1", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(_clientToBeEdited)) });
            _editedClient = _sut.UpdateClient(new Models.IuguClient("1", email: "teste@mail.com")).Result;
        }

        [When(@"I request the client to be edited sync")]
        public void WhenIRequestTheClientToBeEditedSync()
        {
            _httpClient.PutAsJsonAsync("/customers/1", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(_clientToBeEdited)) });
            _editedClient = _sut.UpdateClientSync(_client);
        }

        [Then(@"the request should be a POST")]
        public Task ThenTheRequestShouldBeAPOST()
            => AssertThatRequestMatches(h => h.Method == HttpMethod.Post);

        [Then(@"should send Json object into the body")]
        public Task ThenShouldSendJsonObjectIntoTheBody()
            => AssertThatRequestMatches(h => h.Content.Headers.ContentType.MediaType == "application/json");

        [Then(@"the url should end with ""(.*)""")]
        public Task ThenTheUrlShouldEndWith(string uri)
            => AssertThatRequestMatches(h => h.RequestUri.ToString() == uri);

        [Then(@"should return a Client created")]
        public void ThenShouldReturnAClientCreated() => Assert.IsNotNull(_createdClient);

        [Then(@"the request should be a PUT")]
        public void ThenTheRequestShouldBeAPUT() => AssertThatRequestMatches(h => h.Method == HttpMethod.Put);

        [Given(@"a id of the client")]
        public void GivenAIdOfTheClient()
        {
            _clientId = "1";
        }

        [When(@"I request the client to be removed")]
        public void WhenIRequestTheClientToBeRemoved()
        {
            _httpClient.DeleteAsync("/customers/1").ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(_clientToBeEdited)) });
            deletedClient = _sut.DeleteClient(_clientId).Result;
        }

        [Then(@"should return a Client edited")]
        public void ThenShouldReturnAClientEdited() => Assert.AreEqual("Fulano", _editedClient.Name);

        [Then(@"the request should be a DELETE")]
        public void ThenTheRequestShouldBeADELETE()
            => AssertThatRequestMatches(h => h.Method == HttpMethod.Delete);

        [Then(@"should send Api Token into the header")]
        public void ThenShouldSendApiTokenIntoTheHeader()
            => AssertThatRequestMatches(h => h.Headers.Contains("api_token"));

        [Then(@"should return a client removed")]
        public void ThenShouldReturnAClientRemoved() => Assert.IsNotNull(deletedClient);


        private Task<HttpResponseMessage> AssertThatRequestMatches(Expression<Predicate<HttpRequestMessage>> expression)
            => _httpClient.Received().SendAsync(Arg.Is(expression), Arg.Any<CancellationToken>());
    }
}

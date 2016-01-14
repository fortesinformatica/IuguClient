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

        [BeforeScenario]
        public void Setup()
        {
            _httpClient = Substitute.For<HttpClient>();
            _sut = new IuguApiClient(_httpClient);

        }

        [Given(@"a Client")]
        public void GivenAClient()
        {
            _client = new Models.IuguClient("teste@mail.com");
        }

        [When(@"I send the client data")]
        public void WhenISendTheClientData()
        {
            _httpClient.PostAsJsonAsync("/customers", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(_client)) });
            _createdClient = _sut.CreateClient(_client).Result;
        }

        [Then(@"the request should be a POST")]
        public Task ThenTheRequestShouldBeAPOST()
            => _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Method == HttpMethod.Post), Arg.Any<CancellationToken>());

        [Then(@"should send Json object into the body")]
        public Task ThenShouldSendJsonObjectIntoTheBody()
            => _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Content.Headers.ContentType.MediaType == "application/json"), Arg.Any<CancellationToken>());

        [Then(@"the url should end with ""(.*)""")]
        public Task ThenTheUrlShouldEndWith(string p0)
            => _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.RequestUri.ToString() == p0), Arg.Any<CancellationToken>());

        [Then(@"should return a Client created")]
        public void ThenShouldReturnAClientCreated() => Assert.IsNotNull(_createdClient);
    }
}

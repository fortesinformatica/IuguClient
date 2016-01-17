using IuguClientAPI;
using IuguClientAPI.Interfaces;
using IuguClientAPI.Models;
using NSubstitute;
using RestSharp;
using TechTalk.SpecFlow;

namespace IuguClient.API.Tests
{
    [Binding]
    public class PaymentMethodCRUDSteps
    {
        private IuguPaymentMethod _paymentMethod;
        private IuguPaymentMethod _createdPaymentMethod;
        private IRestClient _httpClient;
        private IIuguApiPaymentMethod _sut;
        private IRestResponse<IuguPaymentMethod> _restResponse;
        private PaymentData _paymentData;

        [BeforeScenario]
        public void Setup()
        {
            _httpClient = Substitute.For<IRestClient>();
            _restResponse = Substitute.For<IRestResponse<IuguPaymentMethod>>();
            _sut = new IuguApiPaymentMethod(_httpClient);
            _paymentData = new PaymentData("4111111111111111", "123", "Joao", "Silva", "12", "2013");

            _createdPaymentMethod = new IuguPaymentMethod("9B41FB19CBA44913B1EF990A10382E7E", "Meu Cartão de Crédito", "credit_card", null, _paymentData);
        }

        [Given(@"a PaymentMethod")]
        public void GivenAPaymentMethod()
        {
            _paymentMethod = new IuguPaymentMethod("Meu Cartão de Crédito", "credit_card", null, _paymentData);
        }
        
        [When(@"I request the PaymentMethod to be added")]
        public void WhenIRequestThePaymentMethodToBeAdded()
        {
            _restResponse.Data.Returns(_createdPaymentMethod);
            _httpClient.ExecuteTaskAsync<IuguPaymentMethod>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _sut.CreatePaymentMethod(_paymentMethod);
        }
        
        [Then(@"the Request should be a POST")]
        public void ThenTheRequestShouldBeAPOST()
        {
            _httpClient.Received().ExecuteTaskAsync<IuguPaymentMethod>(Arg.Is<IRestRequest>(x => x.Method == Method.POST));
        }

        [Then(@"should send Json object into the body")]
        public void ThenShouldSendJsonObjectIntoTheBody()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the url should end with ""(.*)""")]
        public void ThenTheUrlShouldEndWith(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"should return a PaymentMethod created")]
        public void ThenShouldReturnAPaymentMethodCreated()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

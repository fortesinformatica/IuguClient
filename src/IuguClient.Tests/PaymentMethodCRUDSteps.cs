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
    public class PaymentMethodCRUDSteps
    {
        private IuguPaymentMethod _paymentMethod;
        private IuguPaymentMethod _createdPaymentMethod;
        private IIuguApiClient _sut;
        private IRestResponse<IuguPaymentMethod> _restResponse;
        private PaymentData _paymentData;
        private readonly IRestClient _restClient;
        private IuguPaymentMethod _iuguPaymentMethod;

        public PaymentMethodCRUDSteps()
        {
            _restClient = CrudStepsBase.RestClient = Substitute.For<IRestClient>();
            CrudStepsBase.Asserter = MatchRequest;
            _sut = new IuguApiClient(_restClient);
            _restResponse = Substitute.For<IRestResponse<IuguPaymentMethod>>();
            _paymentData = new PaymentData("4111111111111111", "123", "Joao", "Silva", "12", "2013");

            _createdPaymentMethod = new IuguPaymentMethod("9B41FB19CBA44913B1EF990A10382E7E", "Meu Cartão de Crédito", "credit_card", null, _paymentData);
        }

        private Task<IRestResponse<IuguPaymentMethod>> MatchRequest(Expression<Predicate<IRestRequest>> exp)
            => _restClient.Received().ExecuteTaskAsync<IuguPaymentMethod>(Arg.Is(exp));

        [Given(@"a PaymentMethod")]
        public void GivenAPaymentMethod()
        {
            _paymentMethod = new IuguPaymentMethod("Meu Cartão de Crédito", "credit_card", null, _paymentData);
        }

        [When(@"I request the PaymentMethod to be added")]
        public void WhenIRequestThePaymentMethodToBeAdded()
        {
            _restResponse.Data.Returns(_createdPaymentMethod);
            _restClient.ExecuteTaskAsync<IuguPaymentMethod>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            _iuguPaymentMethod = _sut.CreatePaymentMethod(_paymentMethod).Result;
        }

        [Then(@"should return a PaymentMethod created")]
        public void ThenShouldReturnAPaymentMethodCreated()
        {
            Assert.IsNotNull(_iuguPaymentMethod);
        }
    }
}

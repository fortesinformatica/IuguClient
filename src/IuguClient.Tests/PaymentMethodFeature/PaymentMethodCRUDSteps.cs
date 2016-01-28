using IuguClientAPI.Interfaces;
using IuguClientAPI.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace IuguClientAPI.Tests
{
    [Binding]
    public class PaymentMethodCRUDSteps : BaseStep<IuguPaymentMethod>
    {
        private IuguPaymentMethod _paymentMethod;
        private readonly IuguPaymentMethod _createdPaymentMethod;
        private IuguPaymentMethod _editedPaymentMethod;
        private IuguPaymentMethod _removedPaymentMethod;
        private string paymentMethodId;
        private readonly IIuguApiClientPaymentMethod _sut;
        private readonly PaymentData _paymentData;
        private IuguPaymentMethod _iuguPaymentMethod;

        public PaymentMethodCRUDSteps()
        {
            _sut = new IuguApiClient(_restClient);
            _paymentData = new PaymentData("4111111111111111", "123", "Joao", "Silva", "12", "2013");

            _createdPaymentMethod = new IuguPaymentMethod("2", "Meu Cartão de Crédito", _paymentData, "1321654321", null);
            _editedPaymentMethod = new IuguPaymentMethod("1", "2", "Mudando titulo do pagamento", _paymentData, PaymentOptions.CreditCard, null);
            _removedPaymentMethod = new IuguPaymentMethod("1", "2", "Mudando titulo do pagamento", _paymentData, PaymentOptions.CreditCard, null);
        }

        [Given(@"a PaymentMethod")]
        public void GivenAPaymentMethod() => _paymentMethod = new IuguPaymentMethod("2", "Meu Cartão de Crédito", _paymentData, PaymentOptions.CreditCard, null);

        [Given(@"a id of the paymentMehtod")]
        public void GivenAIdOfThePaymentMehtod() => paymentMethodId = "1";

        [When(@"I request the PaymentMethod to be added")]
        public void WhenIRequestThePaymentMethodToBeAdded() => _iuguPaymentMethod = CallMethodAndMockResponse(() => _sut.CreatePaymentMethod(_paymentMethod).Result, _createdPaymentMethod);

        [When(@"I request the PaymentMethod to be added sync")]
        public void WhenIRequestThePaymentMethodToBeAddedSync()
            => _iuguPaymentMethod = CallMethodAndMockResponse(() => _sut.CreatePaymentMethodSync(_paymentMethod), _createdPaymentMethod);

        [When(@"I request the PaymentMethod to be edited")]
        public void WhenIRequestThePaymentMethodToBeEdited()
            => _editedPaymentMethod = CallMethodAndMockResponse(() => _sut.UpdatePaymentMethod(_editedPaymentMethod, "22").Result, _editedPaymentMethod);

        [When(@"I request the PaymentMethod to be edited sync")]
        public void WhenIRequestThePaymentMethodToBeEditedSync()
            => _editedPaymentMethod = CallMethodAndMockResponse(() => _sut.UpdatePaymentMethodSync(_editedPaymentMethod, "22"), _editedPaymentMethod);

        [When(@"I request the paymentMehtod to be removed")]
        public void WhenIRequestThePaymentMehtodToBeRemoved()
            => _removedPaymentMethod = CallMethodAndMockResponse(() => _sut.DeletePaymentMethod(paymentMethodId).Result, _removedPaymentMethod);

        [When(@"I request the paymentMehtod to be removed sync")]
        public void WhenIRequestThePaymentMehtodToBeRemovedSync()
            => _removedPaymentMethod = CallMethodAndMockResponse(() => _sut.DeletePaymentMethodSync(paymentMethodId), _removedPaymentMethod);

        [Then(@"should return a PaymentMethod created")]
        public void ThenShouldReturnAPaymentMethodCreated() => Assert.IsNotNull(_iuguPaymentMethod);

        [Then(@"should return a PaymentMethod edited")]
        public void ThenShouldReturnAPaymentMethodEdited() => Assert.AreEqual("Mudando titulo do pagamento", _editedPaymentMethod.Description);

        [Then(@"should return a paymentMehtod removed")]
        public void ThenShouldReturnAPaymentMehtodRemoved() => Assert.IsNotNull(_removedPaymentMethod);
    }
}

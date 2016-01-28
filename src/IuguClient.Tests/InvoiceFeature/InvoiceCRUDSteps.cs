using System;
using System.Collections.Generic;
using IuguClientAPI.Interfaces;
using IuguClientAPI.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace IuguClientAPI.Tests.InvoiceFeature
{
    [Binding]
    public class InvoiceCRUDSteps : BaseStep<IuguInvoice>
    {
        private readonly IIuguApiClient _sut;
        private IuguInvoice _invoiceToCreate;
        private IuguInvoice _createdInvoice;
        private IuguInvoice _editedInvoice;
        private IuguInvoice _removedInvoice;
        private IuguInvoice _duplicatedInvoice;
        private IuguInvoice _canceledInvoice;
        private IuguInvoice _refundedInvoice;
        private IuguInvoice _retrievedInvoice;
        private string _invoiceId;

        public InvoiceCRUDSteps()
        {
            _sut = new IuguApiClient(_restClient);
            _createdInvoice = _editedInvoice = _removedInvoice = _duplicatedInvoice = _canceledInvoice = _refundedInvoice = _retrievedInvoice = new IuguInvoice("0958D2AAD34049AB889583E26DFA0BF1", "teste@teste.com", DateTime.Now, new List<IuguInvoiceItem> { new IuguInvoiceItem("Item um", 1, 1000) }, null, null, null, null, null, null, null, null, null, null, PaymentOptions.CreditCard, null, null, null);
        }

        [Given(@"a Invoice")]
        public void GivenAInvoice()
            => _invoiceToCreate = new IuguInvoice("teste@teste.com", DateTime.Now, new List<IuguInvoiceItem> { new IuguInvoiceItem("Item um", 1, 1000) });

        [Given(@"a id of the invoice")]
        public void GivenAIdOfTheInvoice() => _invoiceId = "0958D2AAD34049AB889583E26DFA0BF1";

        [When(@"I request the Invoice to be added")]
        public void WhenIRequestTheInvoiceToBeAdded() => _createdInvoice = CallMethodAndMockResponse(() => _sut.CreateInvoice(_invoiceToCreate).Result, _createdInvoice);

        [When(@"I request the Invoice to be added sync")]
        public void WhenIRequestTheInvoiceToBeAddedSync() => _createdInvoice = CallMethodAndMockResponse(() => _sut.CreateInvoiceSync(_invoiceToCreate), _createdInvoice);

        [When(@"I request the Invoice to be edited")]
        public void WhenIRequestTheInvoiceToBeEdited() => _editedInvoice = CallMethodAndMockResponse(() => _sut.UpdateInvoice(_editedInvoice).Result, _editedInvoice);

        [When(@"I request the Invoice to be edited sync")]
        public void WhenIRequestTheInvoiceToBeEditedSync() => _editedInvoice = CallMethodAndMockResponse(() => _sut.UpdateInvoiceSync(_editedInvoice), _editedInvoice);

        [When(@"I request the invoice to be removed")]
        public void WhenIRequestTheInvoiceToBeRemoved() => _removedInvoice = CallMethodAndMockResponse(() => _sut.DeleteInvoice(_createdInvoice.Id).Result, _removedInvoice);

        [When(@"I request the invoice to be removed sync")]
        public void WhenIRequestTheInvoiceToBeRemovedSync() => _removedInvoice = CallMethodAndMockResponse(() => _sut.DeleteInvoiceSync(_createdInvoice.Id), _removedInvoice);

        [When(@"I request the invoice to be duplicated")]
        public void WhenIRequestTheInvoiceToBeDuplicated() => _duplicatedInvoice = CallMethodAndMockResponse(() => _sut.DuplicateInvoice(_createdInvoice).Result, _duplicatedInvoice);

        [When(@"I request the invoice to be duplicated sync")]
        public void WhenIRequestTheInvoiceToBeDuplicatedSync() => _duplicatedInvoice = CallMethodAndMockResponse(() => _sut.DuplicateInvoiceSync(_createdInvoice), _duplicatedInvoice);

        [When(@"I request the invoice to be canceled sync")]
        public void WhenIRequestTheInvoiceToBeCanceledSync() => _canceledInvoice = CallMethodAndMockResponse(() => _sut.CancelInvoiceSync(_createdInvoice.Id), _canceledInvoice);

        [When(@"I request the invoice to be canceled")]
        public void WhenIRequestTheInvoiceToBeCanceled() => _canceledInvoice = CallMethodAndMockResponse(() => _sut.CancelInvoice(_createdInvoice.Id).Result, _canceledInvoice);

        [When(@"I request the invoice to be refunded")]
        public void WhenIRequestTheInvoiceToBeRefunded() => _refundedInvoice = CallMethodAndMockResponse(() => _sut.RefundInvoice(_createdInvoice.Id).Result, _refundedInvoice);

        [When(@"I request the invoice to be refunded sync")]
        public void WhenIRequestTheInvoiceToBeRefundedSync() => _refundedInvoice = CallMethodAndMockResponse(() => _sut.RefundInvoiceSync(_createdInvoice.Id), _refundedInvoice);

        [When(@"I request the invoice to be retrieved")]
        public void WhenIRequestTheInvoiceToBeRetrieved() => _retrievedInvoice = CallMethodAndMockResponse(() => _sut.GetInvoiceById(_createdInvoice.Id).Result, _retrievedInvoice);

        [When(@"I request the invoice to be retrieved sync")]
        public void WhenIRequestTheInvoiceToBeRetrievedSync() => _retrievedInvoice = CallMethodAndMockResponse(() => _sut.GetInvoiceByIdSync(_createdInvoice.Id), _retrievedInvoice);

        [Then(@"should return a invoice duplicated")]
        public void ThenShouldReturnAInvoiceDuplicated() => Assert.IsNotNull(_duplicatedInvoice);

        [Then(@"should return a invoice removed")]
        public void ThenShouldReturnAInvoiceRemoved() => Assert.IsNotNull(_removedInvoice);

        [Then(@"should return a Invoice edited")]
        public void ThenShouldReturnAInvoiceEdited() => Assert.IsNotNull(_editedInvoice);

        [Then(@"should return a Invoice created")]
        public void ThenShouldReturnAInvoiceCreated() => Assert.IsNotNull(_createdInvoice);

        [Then(@"should return a invoice canceled")]
        public void ThenShouldReturnAInvoiceCanceled() => Assert.IsNotNull(_canceledInvoice);

        [Then(@"should return a invoice retrieved")]
        public void ThenShouldReturnAInvoiceRetrieved() => Assert.IsNotNull(_retrievedInvoice);
    }
}

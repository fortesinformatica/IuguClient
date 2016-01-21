using IuguClientAPI.Interfaces;
using IuguClientAPI.Models;
using IuguClientAPI.Tests.Serialization;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace IuguClientAPI.Tests
{
    [Binding]
    public class CustomerCRUDSteps : BaseStep<IuguCustomer>
    {
        private readonly IIuguApiClient _sut;
        private IuguCustomer _customer;
        private IuguCustomer _createdCustomer;
        private IuguCustomer _editedCustomer;
        private string _clientId;
        private IuguCustomer _deletedCustomer;

        public CustomerCRUDSteps()
        {
            _sut = new IuguApiClient(_restClient);
            _createdCustomer = _editedCustomer = _deletedCustomer = CustomerSerializationTest.IuguCustomer;
        }

        [Given(@"a Customer")]
        public void GivenAClient() => _customer = new IuguCustomer("teste@mail.com");

        [Given(@"a id of the customer")]
        public void GivenAIdOfTheClient() => _clientId = "1";

        [When(@"I request the customer to be removed")]
        public void WhenIRequestTheClientToBeRemoved() => _deletedCustomer = CallMethodAndMockResponse(() => _sut.DeleteClient(_clientId).Result, _deletedCustomer);

        [When(@"I request the customer to be removed sync")]
        public void WhenIRequestTheClientToBeRemovedSync() => _deletedCustomer = CallMethodAndMockResponse(() => _sut.DeleteClientSync(_clientId), _deletedCustomer);

        [When(@"I request the customer to be added")]
        public void WhenIRequestTheClientToBeAdded() => _createdCustomer = CallMethodAndMockResponse(() => _sut.CreateClient(_customer).Result, _createdCustomer);

        [When(@"I request the customer to be added sync")]
        public void WhenIRequestTheClientToBeAddedSync() => _createdCustomer = CallMethodAndMockResponse(() => _sut.CreateClientSync(_customer), _createdCustomer);

        [When(@"I request the customer to be edited")]
        public void WhenIRequestTheClientToBeEdited() => _editedCustomer = CallMethodAndMockResponse(() => _sut.UpdateClient(CustomerSerializationTest.IuguCustomer).Result, _editedCustomer);

        [When(@"I request the customer to be edited sync")]
        public void WhenIRequestTheClientToBeEditedSync() => _editedCustomer = CallMethodAndMockResponse(() => _sut.UpdateClientSync(CustomerSerializationTest.IuguCustomer), _editedCustomer);

        [Then(@"should return a Customer created")]
        public void ThenShouldReturnAClientCreated() => Assert.IsNotNull(_createdCustomer);

        [Then(@"should return a Customer edited")]
        public void ThenShouldReturnAClientEdited() => Assert.AreEqual("Nome do Cliente", _editedCustomer.Name);

        [Then(@"should return a customer removed")]
        public void ThenShouldReturnAClientRemoved() => Assert.IsNotNull(_deletedCustomer);
    }
}

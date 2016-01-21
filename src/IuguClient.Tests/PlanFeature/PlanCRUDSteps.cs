using IuguClientAPI.Interfaces;
using IuguClientAPI.Models;
using IuguClientAPI.Tests.Serialization;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace IuguClientAPI.Tests.PlanFeature
{
    [Binding]
    public class PlanCRUDSteps : BaseStep<IuguPlan>
    {
        private readonly IIuguApiPlanClient _sut;
        private readonly IuguPlan _planToUpdate;
        private readonly IuguPlan _planToDelete;
        private IuguPlan _plan;
        private string _id;
        private readonly IuguPlan _planToAdd;
        private IuguPlan _planUpdated;
        private IuguPlan _planDeleted;
        private IuguPlan _planGot;
        private IuguPlan _planAdded;

        public PlanCRUDSteps()
        {
            _sut = new IuguApiClient(_restClient);

            _plan = new IuguPlan("Core", "core_basico", 1, IuguIntervalType.Months, IuguCurrencyType.BRL, 7500);
            _planToAdd = PlanSerializationTest.IuguPlan;
            _planToUpdate = PlanSerializationTest.IuguPlan;
            _planToDelete = PlanSerializationTest.IuguPlan;
        }

        [Given(@"a Plan")]
        public void GivenAPlan() => _plan = new IuguPlan("Core", "core_basico", 1, IuguIntervalType.Months, IuguCurrencyType.BRL, 7500);

        [Given(@"a id of the plan")]
        public void GivenAIdOfThePlan() => _id = PlanSerializationTest.IuguPlan.Id;

        [When(@"I request the plan to be added")]
        public void WhenIRequestThePlanToBeAdded() => _planAdded = CallMethodAndMockResponse(() => _sut.CreatePlan(_plan).Result, _planToAdd);

        [When(@"I request the plan to be added sync")]
        public void WhenIRequestThePlanToBeAddedSync() => _planAdded = CallMethodAndMockResponse(() => _sut.CreatePlanSync(_plan), _planToAdd);

        [When(@"I request the plan to be edited")]
        public void WhenIRequestThePlanToBeEdited() => _planUpdated = CallMethodAndMockResponse(() => _sut.UpdatePlan(_planToUpdate).Result, _planToUpdate);

        [When(@"I request the plan to be edited sync")]
        public void WhenIRequestThePlanToBeEditedSync() => _planUpdated = CallMethodAndMockResponse(() => _sut.UpdatePlanSync(_planToUpdate), _planToUpdate);

        [When(@"I request the plan to be removed")]
        public void WhenIRequestThePlanToBeRemoved() => _planDeleted = CallMethodAndMockResponse(() => _sut.DeletePlan(_id).Result, _planToDelete);

        [When(@"I request the plan to be removed sync")]
        public void WhenIRequestThePlanToBeRemovedSync() => _planDeleted = CallMethodAndMockResponse(() => _sut.DeletePlanSync(_id), _planToDelete);

        [When(@"I request the plan to be got")]
        public void WhenIRequestThePlanToBeGot() => _planGot = CallMethodAndMockResponse(() => _sut.GetPlan(_id).Result, _plan);

        [When(@"I request the plan to be got sync")]
        public void WhenIRequestThePlanToBeGotSync() => _planGot = CallMethodAndMockResponse(() => _sut.GetPlanSync(_id), _plan);

        [Then(@"should return a Plan created")]
        public void ThenShouldReturnAPlanCreated() => Assert.IsNotNull(_planAdded);

        [Then(@"should return a Plan edited")]
        public void ThenShouldReturnAPlanEdited() => Assert.IsNotNull(_planUpdated);

        [Then(@"should return a plan removed")]
        public void ThenShouldReturnAPlanRemoved() => Assert.IsNotNull(_planDeleted);

        [Then(@"should return a plan got")]
        public void ThenShouldReturnAPlanGot() => Assert.IsNotNull(_planGot);
    }
}

using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI
{
    public partial class IuguApiClient
    {
        public async Task<IuguPlan> CreatePlan(IuguPlan plan) => await Post(plan, "/plans");

        public IuguPlan CreatePlanSync(IuguPlan plan) => PostSync(plan, "/plans");

        public async Task<IuguPlan> UpdatePlan(IuguPlan plan) => await Put(plan, plan.Id, "/plans/{id}");

        public IuguPlan UpdatePlanSync(IuguPlan plan) => PutSync(plan, plan.Id, "/plans/{id}");

        public async Task<IuguPlan> DeletePlan(string planId) => await Delete<IuguPlan>(planId, "/plans/{id}");

        public IuguPlan DeletePlanSync(string planId) => DeleteSync<IuguPlan>(planId, "/plans/{id}");

        public async Task<IuguPlan> GetPlan(string planId) => await Get<IuguPlan>(planId, "/plans/{id}");

        public IuguPlan GetPlanSync(string planId) => GetSync<IuguPlan>(planId, "/plans/{id}");

        public async Task<IuguPlan> GetPlanWithIdentifier(string planId) => await Get<IuguPlan>(planId, "/plans/identifier/{id}");

        public IuguPlan GetPlanWithIdentifierSync(string planId) => GetSync<IuguPlan>(planId, "/plans/identifier/{id}");
    }
}

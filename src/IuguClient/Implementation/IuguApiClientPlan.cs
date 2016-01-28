using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI
{
    public partial class IuguApiClient
    {
        public async Task<IuguPlan> CreatePlan(IuguPlan plan) => await Post(plan, "/plans");

        public IuguPlan CreatePlanSync(IuguPlan plan) => Post(plan, "/plans").Result;

        public async Task<IuguPlan> UpdatePlan(IuguPlan plan) => await Put(plan, plan.Id, "/plans/{id}");

        public IuguPlan UpdatePlanSync(IuguPlan plan) => Put(plan, plan.Id, "/plans/{id}").Result;

        public async Task<IuguPlan> DeletePlan(string planId) => await Delete<IuguPlan>(planId, "/plans/{id}");

        public IuguPlan DeletePlanSync(string planId) => Delete<IuguPlan>(planId, "/plans/{id}").Result;

        public async Task<IuguPlan> GetPlan(string planId) => await Get<IuguPlan>(planId, "/plans/{id}");

        public IuguPlan GetPlanSync(string planId) => Get<IuguPlan>(planId, "/plans/{id}").Result;

        public async Task<IuguPlan> GetPlanWithIdentifier(string planId) => await Get<IuguPlan>(planId, "/plans/identifier/{id}");

        public IuguPlan GetPlanWithIdentifierSync(string planId) => Get<IuguPlan>(planId, "/plans/identifier/{id}").Result;
    }
}

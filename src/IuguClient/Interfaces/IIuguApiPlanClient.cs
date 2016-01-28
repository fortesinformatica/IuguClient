using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI.Interfaces
{
    public interface IIuguApiPlanClient
    {
        Task<IuguPlan> CreatePlan(IuguPlan plan);
        IuguPlan CreatePlanSync(IuguPlan plan);
        Task<IuguPlan> UpdatePlan(IuguPlan plan);
        IuguPlan UpdatePlanSync(IuguPlan plan);
        Task<IuguPlan> DeletePlan(string planId);
        IuguPlan DeletePlanSync(string planId);
        Task<IuguPlan> GetPlan(string planId);
        IuguPlan GetPlanSync(string planId);
        Task<IuguPlan> GetPlanWithIdentifier(string identifier);
        IuguPlan GetPlanWithIdentifierSync(string identifier);
    }
}
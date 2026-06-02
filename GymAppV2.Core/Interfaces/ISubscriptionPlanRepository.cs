using GymAppV2.Core.Entities;

namespace GymAppV2.Core.Interfaces
{
    public interface ISubscriptionPlanRepository : IRepository<SubscriptionPlan>
    {
        Task<IEnumerable<SubscriptionPlan>> GetActivePlansAsync();
    }
}

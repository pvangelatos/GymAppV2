using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;
using GymAppV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAppV2.Infrastructure.Repositories
{
    public class SubscriptionPlanRepository : Repository<SubscriptionPlan>, ISubscriptionPlanRepository
    {
        public SubscriptionPlanRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<SubscriptionPlan>> GetActivePlansAsync() =>
            await _dbSet.Where(p => p.IsActive).ToListAsync();
    }
}

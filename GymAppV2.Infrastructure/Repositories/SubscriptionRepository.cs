using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;
using GymAppV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAppV2.Infrastructure.Repositories
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Subscription>> GetByMemberIdAsync(int memberId) =>
            await _dbSet
                .Include(s => s.Plan)
                .Include(s => s.Member)
                .Where(s => s.MemberId == memberId)
                .ToListAsync();

        public async Task<Subscription?> GetActiveByMemberIdAsync(int memberId) =>
            await _dbSet
                .Include(s => s.Plan)
                .Include(s => s.Member)
                .FirstOrDefaultAsync(s => s.MemberId == memberId && s.IsActive);

        public async Task<IEnumerable<Subscription>> GetExpiredAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            return await _dbSet
                .Include(s => s.Plan)
                .Include(s => s.Member)
                .Where(s => s.IsActive && s.EndDate < today)
                .ToListAsync();
        }
    }
}

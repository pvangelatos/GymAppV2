using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;
using GymAppV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAppV2.Infrastructure.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(AppDbContext context) : base(context) { }

        public async Task<Member?> GetByEmailAsync(string email) =>
            await _dbSet.FirstOrDefaultAsync(m => m.Email == email);

        public async Task<IEnumerable<Member>> GetActiveMembersAsync() =>
            await _dbSet.Where(m => m.IsActive).ToListAsync();

        public async Task<Member?> GetWithSubscriptionsAsync(int id) =>
            await _dbSet
                .Include(m => m.Subscriptions)
                    .ThenInclude(s => s.Plan)
                .FirstOrDefaultAsync(m => m.Id == id);
    }
}

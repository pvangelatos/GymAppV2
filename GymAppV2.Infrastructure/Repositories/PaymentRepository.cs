using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;
using GymAppV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAppV2.Infrastructure.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Payment>> GetBySubscriptionIdAsync(int subscriptionId) =>
            await _dbSet
                .Where(p => p.SubscriptionId == subscriptionId)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
    }
}

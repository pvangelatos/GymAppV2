using GymAppV2.Core.Entities;

namespace GymAppV2.Core.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetBySubscriptionIdAsync(int subscriptionId);
    }
}

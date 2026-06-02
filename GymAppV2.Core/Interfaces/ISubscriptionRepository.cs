using System;
using System.Collections.Generic;
using System.Text;
using GymAppV2.Core.Entities;

namespace GymAppV2.Core.Interfaces
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        
        Task<IEnumerable<Subscription>> GetByMemberIdAsync(int memberId);

        Task<Subscription?> GetActiveByMemberIdAsync(int memberId);
        Task<IEnumerable<Subscription>> GetExpiredAsync();
    }
}

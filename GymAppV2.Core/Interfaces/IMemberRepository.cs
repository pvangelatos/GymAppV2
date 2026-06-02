using GymAppV2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppV2.Core.Interfaces
{
    public interface IMemberRepository : IRepository<Member>
    {
        Task<Member?> GetByEmailAsync(string email);
        Task<IEnumerable<Member>> GetActiveMembersAsync();
        Task<Member?> GetWithSubscriptionsAsync(int id);
    }
}

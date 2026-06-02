using System;
using System.Collections.Generic;
using System.Text;
using GymAppV2.Core.Entities;

namespace GymAppV2.Core.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetByMemberIdAsync(int memberId);
        Task<int> GetBookingCountForSlotAsync(int timeSlotId, DateOnly date);
    }
}

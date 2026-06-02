using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;
using GymAppV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAppV2.Infrastructure.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Booking>> GetByMemberIdAsync(int memberId) =>
            await _dbSet
                .Include(b => b.Member)
                .Include(b => b.TimeSlot)
                    .ThenInclude(ts => ts.GymProgram)
                .Where(b => b.MemberId == memberId)
                .ToListAsync();

        public async Task<int> GetBookingCountForSlotAsync(int timeSlotId, DateOnly date) =>
            await _dbSet.CountAsync(b =>
                b.TimeSlotId == timeSlotId &&
                b.BookingDate == date &&
                b.Status != BookingStatus.Cancelled);
    }
}

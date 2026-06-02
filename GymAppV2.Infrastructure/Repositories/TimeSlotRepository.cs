using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;
using GymAppV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAppV2.Infrastructure.Repositories
{
    public class TimeSlotRepository : Repository<TimeSlot>, ITimeSlotRepository
    {
        public TimeSlotRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<TimeSlot>> GetByProgramIdAsync(int programId) =>
            await _dbSet
                .Include(ts => ts.GymProgram)
                .Where(ts => ts.GymProgramId == programId)
                .ToListAsync();

        public async Task<IEnumerable<TimeSlot>> GetAvailableSlotsAsync(int programId, DateOnly date)
        {
            var slots = await _dbSet
                .Include(ts => ts.GymProgram)
                .Include(ts => ts.Bookings)
                .Where(ts => ts.GymProgramId == programId && ts.DayOfWeek == date.DayOfWeek)
                .ToListAsync();

            return slots.Where(ts =>
                ts.Bookings.Count(b => b.BookingDate == date && b.Status != BookingStatus.Cancelled)
                < ts.GymProgram.Capacity);
        }
    }
}

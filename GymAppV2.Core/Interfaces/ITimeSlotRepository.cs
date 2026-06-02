using GymAppV2.Core.Entities;

namespace GymAppV2.Core.Interfaces
{
    public interface ITimeSlotRepository : IRepository<TimeSlot>
    {
        Task<IEnumerable<TimeSlot>> GetByProgramIdAsync(int programId);
        Task<IEnumerable<TimeSlot>> GetAvailableSlotsAsync(int programId, DateOnly date);
    }
}

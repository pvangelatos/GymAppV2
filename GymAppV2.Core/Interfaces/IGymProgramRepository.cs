using GymAppV2.Core.Entities;

namespace GymAppV2.Core.Interfaces
{
    public interface IGymProgramRepository : IRepository<GymProgram>
    {
        Task<IEnumerable<GymProgram>> GetByTrainerIdAsync(int trainerId);
        Task<GymProgram?> GetWithTimeSlotsAsync(int id);
    }
}

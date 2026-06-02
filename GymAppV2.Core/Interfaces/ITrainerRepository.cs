using GymAppV2.Core.Entities;

namespace GymAppV2.Core.Interfaces
{
    public interface ITrainerRepository : IRepository<Trainer>
    {
        Task<Trainer?> GetByEmailAsync(string email);
        Task<IEnumerable<Trainer>> GetActiveTrainersAsync();
        Task<Trainer?> GetWithProgramsAsync(int id);
    }
}

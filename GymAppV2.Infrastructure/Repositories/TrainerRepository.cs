using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;
using GymAppV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAppV2.Infrastructure.Repositories
{
    public class TrainerRepository : Repository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(AppDbContext context) : base(context) { }

        public async Task<Trainer?> GetByEmailAsync(string email) =>
            await _dbSet.FirstOrDefaultAsync(t => t.Email == email);

        public async Task<IEnumerable<Trainer>> GetActiveTrainersAsync() =>
            await _dbSet.Where(t => t.IsActive).ToListAsync();

        public async Task<Trainer?> GetWithProgramsAsync(int id) =>
            await _dbSet
                .Include(t => t.Programs)
                .FirstOrDefaultAsync(t => t.Id == id);
    }
}

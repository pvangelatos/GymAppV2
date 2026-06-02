using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;
using GymAppV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAppV2.Infrastructure.Repositories
{
    public class GymProgramRepository : Repository<GymProgram>, IGymProgramRepository
    {
        public GymProgramRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<GymProgram>> GetByTrainerIdAsync(int trainerId) =>
            await _dbSet
                .Include(p => p.Trainer)
                .Where(p => p.TrainerId == trainerId)
                .ToListAsync();

        public async Task<GymProgram?> GetWithTimeSlotsAsync(int id) =>
            await _dbSet
                .Include(p => p.Trainer)
                .Include(p => p.TimeSlots)
                .FirstOrDefaultAsync(p => p.Id == id);
    }
}

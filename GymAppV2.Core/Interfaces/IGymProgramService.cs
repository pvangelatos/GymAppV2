using GymAppV2.Core.DTOs;

namespace GymAppV2.Core.Interfaces
{
    public interface IGymProgramService
    {
        Task<IEnumerable<GymProgramDto>> GetAllAsync();
        Task<GymProgramDto?> GetByIdAsync(int id);
        Task<GymProgramDto> CreateAsync(CreateGymProgramDto dto);
        Task<GymProgramDto> UpdateAsync(int id, UpdateGymProgramDto dto);
        Task DeleteAsync(int id);
    }
}

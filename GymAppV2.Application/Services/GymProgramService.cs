using AutoMapper;
using GymAppV2.Core.DTOs;
using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;

namespace GymAppV2.Application.Services
{
    public class GymProgramService : IGymProgramService
    {
        private readonly IGymProgramRepository _gymProgramRepository;
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public GymProgramService(
            IGymProgramRepository gymProgramRepository,
            ITrainerRepository trainerRepository,
            IMapper mapper)
        {
            _gymProgramRepository = gymProgramRepository;
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GymProgramDto>> GetAllAsync()
        {
            var programs = await _gymProgramRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GymProgramDto>>(programs);
        }

        public async Task<GymProgramDto?> GetByIdAsync(int id)
        {
            var program = await _gymProgramRepository.GetByIdAsync(id);
            return program is null ? null : _mapper.Map<GymProgramDto>(program);
        }

        public async Task<GymProgramDto> CreateAsync(CreateGymProgramDto dto)
        {
            if (!await _trainerRepository.ExistAsync(dto.TrainerId))
                throw new KeyNotFoundException($"Trainer with id {dto.TrainerId} not found.");

            var program = _mapper.Map<GymProgram>(dto);
            await _gymProgramRepository.AddAsync(program);
            return _mapper.Map<GymProgramDto>(program);
        }

        public async Task<GymProgramDto> UpdateAsync(int id, UpdateGymProgramDto dto)
        {
            var program = await _gymProgramRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Gym program with id {id} not found.");
            _mapper.Map(dto, program);
            program.UpdatedAt = DateTime.UtcNow;
            await _gymProgramRepository.UpdateAsync(program);
            return _mapper.Map<GymProgramDto>(program);
        }

        public async Task DeleteAsync(int id)
        {
            if (!await _gymProgramRepository.ExistAsync(id))
                throw new KeyNotFoundException($"Gym program with id {id} not found.");
            await _gymProgramRepository.DeleteAsync(id);
        }
    }
}

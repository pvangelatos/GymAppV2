using AutoMapper;
using GymAppV2.Core.DTOs;
using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;

namespace GymAppV2.Application.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public TrainerService(ITrainerRepository trainerRepository, IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrainerDto>> GetAllAsync()
        {
            var trainers = await _trainerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TrainerDto>>(trainers);
        }

        public async Task<TrainerDto?> GetByIdAsync(int id)
        {
            var trainer = await _trainerRepository.GetByIdAsync(id);
            return trainer is null ? null : _mapper.Map<TrainerDto>(trainer);
        }

        public async Task<TrainerDto> CreateAsync(CreateTrainerDto dto)
        {
            var existing = await _trainerRepository.GetByEmailAsync(dto.Email);
            if (existing is not null)
                throw new InvalidOperationException($"A trainer with email '{dto.Email}' already exists.");

            var trainer = _mapper.Map<Trainer>(dto);
            await _trainerRepository.AddAsync(trainer);
            return _mapper.Map<TrainerDto>(trainer);
        }

        public async Task<TrainerDto> UpdateAsync(int id, UpdateTrainerDto dto)
        {
            var trainer = await _trainerRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Trainer with id {id} not found.");
            _mapper.Map(dto, trainer);
            trainer.UpdatedAt = DateTime.UtcNow;
            await _trainerRepository.UpdateAsync(trainer);
            return _mapper.Map<TrainerDto>(trainer);
        }

        public async Task DeleteAsync(int id)
        {
            if (!await _trainerRepository.ExistAsync(id))
                throw new KeyNotFoundException($"Trainer with id {id} not found.");
            await _trainerRepository.DeleteAsync(id);
        }
    }
}

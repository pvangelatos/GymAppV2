using AutoMapper;
using GymAppV2.Core.DTOs;
using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;

namespace GymAppV2.Application.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ISubscriptionPlanRepository _planRepository;
        private readonly IMapper _mapper;

        public SubscriptionService(
            ISubscriptionRepository subscriptionRepository,
            ISubscriptionPlanRepository planRepository,
            IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _planRepository = planRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubscriptionDto>> GetAllAsync()
        {
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);
        }

        public async Task<SubscriptionDto?> GetByIdAsync(int id)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id);
            return subscription is null ? null : _mapper.Map<SubscriptionDto>(subscription);
        }

        public async Task<IEnumerable<SubscriptionDto>> GetByMemberIdAsync(int memberId)
        {
            var subscriptions = await _subscriptionRepository.GetByMemberIdAsync(memberId);
            return _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);
        }

        public async Task<SubscriptionDto?> GetActiveByMemberIdAsync(int memberId)
        {
            var subscription = await _subscriptionRepository.GetActiveByMemberIdAsync(memberId);
            return subscription is null ? null : _mapper.Map<SubscriptionDto>(subscription);
        }

        public async Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto dto)
        {
            var plan = await _planRepository.GetByIdAsync(dto.SubscriptionPlanId)
                ?? throw new KeyNotFoundException($"Subscription plan with id {dto.SubscriptionPlanId} not found.");

            var subscription = _mapper.Map<Subscription>(dto);
            subscription.EndDate = dto.StartDate.AddDays(plan.DurationDays);
            subscription.SessionsRemaining = plan.SessionsIncluded;

            await _subscriptionRepository.AddAsync(subscription);
            return _mapper.Map<SubscriptionDto>(subscription);
        }

        public async Task CancelAsync(int id)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Subscription with id {id} not found.");

            if (!subscription.IsActive)
                throw new InvalidOperationException("Subscription is already inactive.");

            subscription.IsActive = false;
            subscription.UpdatedAt = DateTime.UtcNow;
            await _subscriptionRepository.UpdateAsync(subscription);
        }
    }
}

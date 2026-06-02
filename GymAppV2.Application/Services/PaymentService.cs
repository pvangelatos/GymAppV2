using AutoMapper;
using GymAppV2.Core.DTOs;
using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;

namespace GymAppV2.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public PaymentService(
            IPaymentRepository paymentRepository,
            ISubscriptionRepository subscriptionRepository,
            IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> GetBySubscriptionIdAsync(int subscriptionId)
        {
            var payments = await _paymentRepository.GetBySubscriptionIdAsync(subscriptionId);
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto> CreateAsync(CreatePaymentDto dto)
        {
            if (!await _subscriptionRepository.ExistAsync(dto.SubscriptionId))
                throw new KeyNotFoundException($"Subscription with id {dto.SubscriptionId} not found.");

            var payment = _mapper.Map<Payment>(dto);
            payment.PaymentDate = DateTime.UtcNow;
            await _paymentRepository.AddAsync(payment);
            return _mapper.Map<PaymentDto>(payment);
        }
    }
}

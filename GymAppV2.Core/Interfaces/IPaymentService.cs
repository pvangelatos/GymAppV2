using GymAppV2.Core.DTOs;

namespace GymAppV2.Core.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetBySubscriptionIdAsync(int subscriptionId);
        Task<PaymentDto> CreateAsync(CreatePaymentDto dto);
    }
}

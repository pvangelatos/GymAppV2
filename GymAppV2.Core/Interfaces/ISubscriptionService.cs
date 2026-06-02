using GymAppV2.Core.DTOs;

namespace GymAppV2.Core.Interfaces
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionDto>> GetAllAsync();
        Task<SubscriptionDto?> GetByIdAsync(int id);
        Task<IEnumerable<SubscriptionDto>> GetByMemberIdAsync(int memberId);
        Task<SubscriptionDto?> GetActiveByMemberIdAsync(int memberId);
        Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto dto);
        Task CancelAsync(int id);
    }
}

using GymAppV2.Core.DTOs;

namespace GymAppV2.Core.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllAsync();
        Task<BookingDto?> GetByIdAsync(int id);
        Task<IEnumerable<BookingDto>> GetByMemberIdAsync(int memberId);
        Task<BookingDto> CreateAsync(CreateBookingDto dto);
        Task CancelAsync(int id);
        Task ConfirmAsync(int id);

        Task DeleteAsync(int id);
    }
}

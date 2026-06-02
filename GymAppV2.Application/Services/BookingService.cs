using AutoMapper;
using GymAppV2.Core.DTOs;
using GymAppV2.Core.Entities;
using GymAppV2.Core.Interfaces;

namespace GymAppV2.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDto>> GetAllAsync()
        {
            var bookings = await _bookingRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto?> GetByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            return booking is null ? null : _mapper.Map<BookingDto>(booking);
        }

        public async Task<IEnumerable<BookingDto>> GetByMemberIdAsync(int memberId)
        {
            var bookings = await _bookingRepository.GetByMemberIdAsync(memberId);
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> CreateAsync(CreateBookingDto dto)
        {
            var booking = _mapper.Map<Booking>(dto);
            await _bookingRepository.AddAsync(booking);
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task CancelAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Booking with id {id} not found.");

            if (booking.Status == BookingStatus.Cancelled)
                throw new InvalidOperationException("Booking is already cancelled.");

            booking.Status = BookingStatus.Cancelled;
            booking.UpdatedAt = DateTime.UtcNow;
            await _bookingRepository.UpdateAsync(booking);
        }

        public async Task ConfirmAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Booking with id {id} not found.");

            if (booking.Status != BookingStatus.Pending)
                throw new InvalidOperationException("Only pending bookings can be confirmed.");

            booking.Status = BookingStatus.Confirmed;
            booking.UpdatedAt = DateTime.UtcNow;
            await _bookingRepository.UpdateAsync(booking);
        }

        public async Task DeleteAsync(int id) => await _bookingRepository.DeleteAsync(id);
    }
}

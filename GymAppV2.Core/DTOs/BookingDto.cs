using GymAppV2.Core.Entities;

namespace GymAppV2.Core.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string MemberFullName { get; set; } = string.Empty;
        public int TimeSlotId { get; set; }
        public string ProgramName { get; set; } = string.Empty;
        public DateOnly BookingDate { get; set; }
        public BookingStatus Status { get; set; }
    }

    public class CreateBookingDto
    {
        public int MemberId { get; set; }
        public int TimeSlotId { get; set; }
        public DateOnly BookingDate { get; set; }
    }

    public class UpdateBookingStatusDto
    {
        public BookingStatus Status { get; set; }
    }
}

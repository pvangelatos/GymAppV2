using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppV2.Core.Entities
{
    public enum BookingStatus 
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed 
    }

    public class Booking : BaseEntity
    {
        public int MemberId { get; set; }
        public int TimeSlotId { get; set; }
        public DateOnly BookingDate { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        public Member Member { get; set; } = null!;
        public TimeSlot TimeSlot { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppV2.Core.Entities
{
    public class TimeSlot : BaseEntity
    {
        public int GymProgramId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public GymProgram GymProgram { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppV2.Core.Entities
{
    public class Member : BaseEntity
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly Birthdate { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

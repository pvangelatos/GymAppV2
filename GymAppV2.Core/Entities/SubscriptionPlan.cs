using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppV2.Core.Entities
{
    public class SubscriptionPlan : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public int? SessionsIncluded { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppV2.Core.Entities
{
    public class Subscription : BaseEntity
    {
        public int MemberId { get; set; }
        public int SubscriptionPlanId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int? SessionsRemaining { get; set; }
        public Member Member { get; set; } = null!;
        public SubscriptionPlan Plan { get; set; } = null!;
    
    }
}

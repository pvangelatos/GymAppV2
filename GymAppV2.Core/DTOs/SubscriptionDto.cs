namespace GymAppV2.Core.DTOs
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string MemberFullName { get; set; } = string.Empty;
        public int SubscriptionPlanId { get; set; }
        public string PlanName { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsActive { get; set; }
        public int? SessionsRemaining { get; set; }
    }

    public class CreateSubscriptionDto
    {
        public int MemberId { get; set; }
        public int SubscriptionPlanId { get; set; }
        public DateOnly StartDate { get; set; }
    }
}

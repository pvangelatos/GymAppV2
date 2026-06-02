namespace GymAppV2.Core.DTOs
{
    public class SubscriptionPlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public int? SessionsIncluded { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateSubscriptionPlanDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public int? SessionsIncluded { get; set; }
    }

    public class UpdateSubscriptionPlanDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public int? SessionsIncluded { get; set; }
    }
}

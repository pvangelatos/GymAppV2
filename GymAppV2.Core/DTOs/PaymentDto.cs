using GymAppV2.Core.Entities;

namespace GymAppV2.Core.DTOs
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod Method { get; set; }
    }

    public class CreatePaymentDto
    {
        public int SubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
    }
}

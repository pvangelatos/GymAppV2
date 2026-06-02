using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppV2.Core.Entities
{
    public enum PaymentMethod 
    { 
        Cash,
        Card,
        BankTransfer
    }

    public class Payment : BaseEntity
    {
        public int SubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public PaymentMethod Method { get; set; }
        public Subscription Subscription { get; set; } = null!;
    }
}

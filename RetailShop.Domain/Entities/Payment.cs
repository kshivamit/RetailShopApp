using RetailShop.Domain.Common;

namespace RetailShop.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public string Provider { get; set; } // Stripe, Razorpay
        public string TransactionId { get; set; }
        public string Status { get; set; }   // Success, Failed, Pending
        public decimal Amount { get; set; }
    }
}
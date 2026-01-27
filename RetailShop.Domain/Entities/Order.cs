using RetailShop.Domain.Common;

namespace RetailShop.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // Pending, Paid, Shipped, Delivered

        public ICollection<OrderItem> Items { get; set; }
        public Payment Payment { get; set; }
    }
}
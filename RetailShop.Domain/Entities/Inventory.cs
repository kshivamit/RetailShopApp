using RetailShop.Domain.Common;

namespace RetailShop.Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
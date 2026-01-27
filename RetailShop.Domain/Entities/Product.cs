using RetailShop.Domain.Common;

namespace RetailShop.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public Inventory Inventory { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
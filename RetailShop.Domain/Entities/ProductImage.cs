using RetailShop.Domain.Common;

namespace RetailShop.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
    }
}
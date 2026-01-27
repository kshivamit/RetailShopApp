using RetailShop.Domain.Common;

namespace RetailShop.Domain.Entities
{
        public class Review : BaseEntity
        {
            public Guid ProductId { get; set; }
            public Product Product { get; set; }

            public Guid UserId { get; set; }
            public User User { get; set; }

            public int Rating { get; set; } // 1–5
            public string Comment { get; set; }
        }
}
using RetailShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Domain.Entities
{
    public class User : BaseEntity
    {
        //public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}

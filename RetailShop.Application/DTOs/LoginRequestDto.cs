using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Application.DTOs
{
    public class LoginRequestDto
    {
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}

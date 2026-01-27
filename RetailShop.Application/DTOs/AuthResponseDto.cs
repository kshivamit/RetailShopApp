using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Application.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }
}

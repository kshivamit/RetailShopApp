using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto.Generators;
using RetailShop.Application.DTOs;
using RetailShop.Application.Interfaces;
using RetailShop.Domain.Entities;
using RetailShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly RetailShopDbContext _context;
        private readonly IConfiguration _config;
        public AuthService(RetailShopDbContext context, IConfiguration config)
        {
            _context = context;   
            _config = config;
        }

        public Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(RegisterRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

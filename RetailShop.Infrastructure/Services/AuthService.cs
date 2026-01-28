using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto.Generators;
using RetailShop.Application.DTOs;
using RetailShop.Application.Interfaces;
using RetailShop.Domain.Entities;
using RetailShop.Infrastructure.Data;
using RetailShop.Infrastructure.Helper;
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

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return null;
            
            if(new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, dto.Password) == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
                return null;

            return new AuthResponseDto
            {
                Token = JwtTokenGenerator.GenerateToken(user, _config),
                //Role = user.Role
            };
        }

        public async Task RegisterAsync(RegisterRequestDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception();

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Role = "Customer"
            };
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, dto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}


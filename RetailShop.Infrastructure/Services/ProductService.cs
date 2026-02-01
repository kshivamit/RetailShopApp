using Microsoft.EntityFrameworkCore;
using RetailShop.Application.DTOs.Product;
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
    public class ProductService : IProductService
    {
        private readonly RetailShopDbContext _context;

        public ProductService(RetailShopDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateAsync(ProductCreateDto dto)
        {
            var product = new Product
            { 
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                Inventory = new Inventory
                {
                    Quantity = dto.InitialStock
                }
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync(); 
            return product.Id;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Inventory)
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    AvailableStock = p.Inventory.Quantity
                }).ToListAsync();
        }

        public Task<ProductResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, ProductCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public async Task<ProductResponseDto> GetByIdAsync(Guid id)
        {
            var product =  await _context.Products.Include(p => p.Category).Include(p => p.Inventory)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }
            else
            {
                return new ProductResponseDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryName = product.Category.Name,
                    AvailableStock = product.Inventory.Quantity
                };
            }
        }

        public async Task UpdateAsync(Guid id, ProductUpdateDto dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new Exception("Product not found");

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Description = dto.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new Exception("Product not found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}

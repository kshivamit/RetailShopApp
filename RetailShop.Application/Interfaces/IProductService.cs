using RetailShop.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<Guid> CreateAsync(ProductCreateDto dto);
        Task<ProductResponseDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ProductResponseDto>> GetAllAsync();
        Task UpdateAsync(Guid id, ProductCreateDto dto);
        Task DeleteAsync(Guid id);

    }
}

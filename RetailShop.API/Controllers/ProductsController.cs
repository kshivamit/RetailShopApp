using LazyCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RetailShop.Application.Common.Pagination;
using RetailShop.Application.DTOs.Product;
using RetailShop.Application.Interfaces;
using RetailShop.Domain.Entities;

namespace RetailShop.API.Controllers
{
    [ApiController]
    [Route("api/auth/products")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly ICacheProvider _cache;
        public ProductsController(IProductService service, ICacheProvider cacheProvider)
        {
            _service = service;
            _cache = cacheProvider;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ProductResponseDto>> GetAllProduct()
        {
            //return (await _service.GetAllAsync());
            if (!_cache.TryGetValue("productsKey", out IEnumerable<ProductResponseDto> products))
            {
                var cacheEntryOption = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(90))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(120))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);

                products = await _service.GetAllAsync();
                _cache.Set("productsKey", products, cacheEntryOption);
                return products;
            }
            return products;
        }

        [HttpGet]
        [Route("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductResponseDto>> GetProductById([FromRoute] Guid id)
        {
            if(!_cache.TryGetValue("productKey", out ActionResult<ProductResponseDto> product))
            {
                var cacheEntryOption = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(90))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(120))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);
                product = await _service.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound("No product found");
                }
                _cache.Set("productKey", product, cacheEntryOption);
                return product;
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductCreateDto dto)
        {
            try
            {
                var productId = await _service.CreateAsync(dto);
                return Ok(productId);
            }
            catch
            {
                return BadRequest("Error creating product");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, ProductUpdateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] PaginationParams paginationParams)
        {
            var pagedResult = await _service.GetPagedAsync(paginationParams);
            return Ok(pagedResult);
        }
    }
}

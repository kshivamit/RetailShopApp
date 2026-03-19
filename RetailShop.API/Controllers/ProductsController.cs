using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailShop.Application.Common.Pagination;
using RetailShop.Application.DTOs.Product;
using RetailShop.Application.Interfaces;

namespace RetailShop.API.Controllers
{
    [ApiController]
    [Route("api/auth/products")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResponseDto>> GetAllProduct()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<ProductResponseDto>> GetProductById([FromRoute] Guid id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound("No product found");
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

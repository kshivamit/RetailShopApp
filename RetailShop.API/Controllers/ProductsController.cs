using Microsoft.AspNetCore.Mvc;
using RetailShop.Application.DTOs.Product;
using RetailShop.Application.Interfaces;

namespace RetailShop.API.Controllers
{
    [ApiController]
    [Route("api/auth/products")]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
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
        [HttpGet]
        public async Task<IEnumerable<ProductResponseDto>> GetAllProduct()
        {
            return (await _service.GetAllAsync());
        }
    }
}

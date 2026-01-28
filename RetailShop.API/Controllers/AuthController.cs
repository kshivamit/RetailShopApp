using Microsoft.AspNetCore.Mvc;
using RetailShop.Application.DTOs;
using RetailShop.Application.Interfaces;

namespace RetailShop.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequestDto dto)
        {
            try
            {
                await _service.RegisterAsync(dto);
                return Ok("User registered successfully");
            }
            catch(Exception)
            {
                return BadRequest("Email already exist");
            }
        }
        
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequestDto dto)
        {
            var response = await _service.LoginAsync(dto);
            if(response == null)
                return BadRequest("Invalid credentials");
            
            return Ok(response);
        }
    }
}

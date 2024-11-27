using CareerPathCore.API.DTOs.Auth;
using CareerPathCore.Application.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace CareerPathCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.Login(request.Email, request.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}

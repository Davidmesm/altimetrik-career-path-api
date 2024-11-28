using CareerPathCore.API.DTOs.Auth;
using CareerPathCore.Application.Services.AuthService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CareerPathCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.Login(request.Email, request.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                await _authService.Register(request.Email, request.Password, request.PasswordConfirmation);
                var token = await _authService.Login(request.Email, request.Password);

                if (token == null)
                    return Unauthorized(new { error = "Invalid credentials" });

                return Ok(new { token });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred during registration");
                return StatusCode(500, new { error = "An unexpected error occurred. Please try again later." });
            }
        }

    }
}

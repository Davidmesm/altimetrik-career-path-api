using CareerPathCore.Contracts;
using CareerPathCore.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CareerPathCore.Application.Services.AuthService.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly string _jwtSecret;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _jwtSecret = configuration["Jwt:Secret"] ?? string.Empty;
        }

        public async Task<string> Login(string? email, string? password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null || user.PasswordHash != HashPassword(password))
                return string.Empty;

            return GenerateJwt(user);
        }

        public async Task Register(string? email, string? password, string? passwordConfirmation)
        {
            if(email == null || password == null || passwordConfirmation == null)
            {
                throw new Exception("Invalid Data");
            }
            
            await _userRepository.AddUser(new User()
            {
                Id = Guid.NewGuid(),
                PasswordHash = HashPassword(password),
                Email = email,
                IsNewUser = true
            });
        }

        private string GenerateJwt(User user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        private string HashPassword(string? password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password ?? string.Empty)));
        }

    }
}

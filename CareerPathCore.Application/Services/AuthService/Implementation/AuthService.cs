using CareerPathCore.Contracts;
using CareerPathCore.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
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
                throw new ValidationException("Invalid email or password. Please try again.");

            return GenerateJwt(user);
        }

        public async Task Register(string? email, string? password, string? passwordConfirmation)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ValidationException("Email is required.");
            if (!email.Contains("@") || !email.Contains("."))
                throw new ValidationException("Invalid email format.");
            if (!email.EndsWith("@altimetrik.com"))
                throw new ValidationException("Email must be from Altimetrik.");
            if (string.IsNullOrWhiteSpace(password))
                throw new ValidationException("Password is required.");
            if (password.Length < 8 || password.Length > 20)
                throw new ValidationException("Password must be between 8 and 20 characters.");
            if (!password.Any(char.IsLower))
                throw new ValidationException("Password must include a lowercase letter.");
            if (!password.Any(char.IsUpper))
                throw new ValidationException("Password must include an uppercase letter.");
            if (!password.Any(char.IsDigit))
                throw new ValidationException("Password must include a number.");
            if (passwordConfirmation == null)
                throw new ValidationException("Confirm Password is required.");
            if (password != passwordConfirmation)
                throw new ValidationException("Confirm Password doesn't match Password.");

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

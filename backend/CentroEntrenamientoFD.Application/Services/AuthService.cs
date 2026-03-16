using BCrypt.Net;
using CentroEntrenamientoFD.Application.Interfaces;
using CentroEntrenamientoFD.Domain.Entities;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CentroEntrenamientoFD.Application.Services
{
    public class AuthService 
    {
        private readonly IUserRepository _usersRepo;
        private readonly string _jwtKey;

        public AuthService(IConfiguration config, IUserRepository userRepository)
        {
            _jwtKey = config["Jwt:Key"];
            _usersRepo = userRepository;
        }

        public async Task<string> RegisterAsync(string email,string fullName, string password)
        {
            var exists = await _usersRepo.GetByEmailAsync(email);

            if (exists != null)
                throw new Exception("User already exists");

            var hash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User(email, fullName, hash);

            await _usersRepo.AddAsync(user);

            return GenerateJwt(user);
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _usersRepo.GetByEmailAsync(email);

            if (user == null)
                throw new Exception("Invalid credentials");

            if (string.IsNullOrEmpty(user.PasswordHash))
                throw new Exception("This account uses Google login");

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            return GenerateJwt(user);
        }

        public async Task<string> LoginWithGoogleAsync(string googleToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new[] { "793591185630-7faqin22nn50689mkoiutk962har944r.apps.googleusercontent.com" }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(googleToken, settings);

            var email = payload.Email;
            var fullName = payload.Name;
            var googleId = payload.Subject;

            var user = await _usersRepo.GetByEmailAsync(email);

            if (user == null)
            {
                user = new User(email, fullName, "", googleId);

                await _usersRepo.AddAsync(user);
            }
            else if (user.GoogleId == null)
            {
                user.SetGoogleId(googleId);
            }

            return GenerateJwt(user);
        }

        private string GenerateJwt(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

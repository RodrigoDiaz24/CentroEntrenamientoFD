using CentroEntrenamientoFD.Application.Interfaces;
using CentroEntrenamientoFD.Domain.Entities;
using Google.Apis.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CentroEntrenamientoFD.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private static readonly List<User> _users = new(); // simula DB por ahora
        private readonly string _jwtKey;

        public AuthService(string jwtKey)
        {
            _jwtKey = jwtKey;
        }

        public async Task<string> RegisterAsync(string email,string fullName, string password)
        {
            var exists = _users.Any(u => u.Email == email);
            if (exists) throw new Exception("User already exists");

            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User(email, fullName, hash);
            _users.Add(user);

            return GenerateJwt(user);
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == email);
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

            var user = _users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                user = new User(email, fullName, "", googleId);
                _users.Add(user);
            }
            else if (user.GoogleId == null)
            {
                user.SetGoogleId(googleId); // método en entidad
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

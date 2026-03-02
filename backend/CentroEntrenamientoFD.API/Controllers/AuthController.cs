using CentroEntrenamientoFD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CentroEntrenamientoFD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var token = await _authService.RegisterAsync(request.Email, request.FullName, request.Password);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var token = await _authService.LoginAsync(request.Email, request.Password);
            return Ok(new { token });
        }

        [HttpPost("google")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginRequest request)
        {
            var token = await _authService.LoginWithGoogleAsync(request.IdToken);
            return Ok(new { token });
        }
    }

    public record RegisterRequest(string Email, string FullName, string Password);
    public record LoginRequest(string Email, string Password);
    public record GoogleLoginRequest(string IdToken);
}

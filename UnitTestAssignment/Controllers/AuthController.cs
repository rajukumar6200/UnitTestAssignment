using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnitTestAssignment.Interface;
using UserOrderSystem.Services;


namespace UnitTestAssignment.Controllers
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

        // GET: api/auth/email-registered?email=test@example.com
        [HttpGet("email-registered")]
        public async Task<IActionResult> IsEmailRegistered([FromQuery] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("Email is required.");

            var isRegistered = await _authService.IsEmailRegisteredAsync(email);
            return Ok(new { email, isRegistered });
        }

        // POST: api/auth/validate-password
        [HttpPost("validate-password")]
        public IActionResult IsValidPassword([FromBody] PasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.Password))
                return BadRequest("Password is required.");

            var isValid = _authService.IsValidPassword(request.Password);
            return Ok(new { request.Password, isValid });
        }
    }

    public class PasswordRequest
    {
        public string Password { get; set; }
    }
}

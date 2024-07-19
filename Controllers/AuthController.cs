using InvoiceSystem.Models;
using InvoiceSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly jwtService _jwtService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration configuration, jwtService jwtService, ILogger<AuthController> logger)
        {
            _configuration = configuration;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Name))
            {
                _logger.LogWarning("Login attempt with invalid data");
                return BadRequest("Invalid user data.");
            }

            var userId =string.Concat(model.Name,model.Password); 
            var token = _jwtService.GenerateToken(userId);
            _logger.LogInformation("User {UserId} logged in successfully", userId);
            return Ok(new { Token = token });
        }
    }
}

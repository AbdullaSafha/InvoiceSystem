using InvoiceSystem.Class;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly jwtService _jwtService;
        
        public AuthController(IConfiguration configuration, jwtService jwtService)
        {
            _configuration = configuration;
            _jwtService = jwtService;   

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var userId = model.userId; // Replace with actual user id
            var token = _jwtService.GenerateToken(model.userId);

            return Ok(new { Token = token });
        }
    }
}

using InvoiceSystem.Class;
using InvoiceSystem.Models;
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

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var userId =string.Concat(model.Name,model.Password); 
            var token = _jwtService.GenerateToken(userId);

            return Ok(new { Token = token });
        }
    }
}

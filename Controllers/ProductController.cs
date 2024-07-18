using InvoiceSystem.Models;
using InvoiceSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddProduct()
        {
            _logger.LogInformation("Logging is working");

            return null;
        }
        //Add product
        //UpdateProduct
        //Delete
        //GetAllProducts
    }
}

using InvoiceSystem.Models;
using InvoiceSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    //[Authorize]
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
        public IActionResult AddProduct(Product product)
        {

            _logger.LogInformation("Logging is working");
            _productService.AddProduct(product);
            return null;
        }


        //Add product
        //UpdateProduct
        //Delete
        //GetAllProducts
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            _logger.LogInformation("Retrieved all products");
            return Ok(products);
        }
    }
}

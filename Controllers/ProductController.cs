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
        //Add product
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {

            _logger.LogInformation("Logging is working");
            _productService.AddProduct(product);
            return Ok();
        }



        //UpdateProduct
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            _productService.UpdateProduct(product);
            _logger.LogInformation("Updated product: {Id}", product.id);
            return Ok();
        }


        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            _logger.LogInformation("Deleted product: {Id}", id);
            return Ok();
        }
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

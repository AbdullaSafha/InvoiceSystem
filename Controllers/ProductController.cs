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
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be empty");
                }

                if (product.name == null || product.price == 0)
                {
                    return BadRequest("Product name and product price cannot be empty");
                }
                _logger.LogInformation("Add product request is recevied");
                _productService.AddProduct(product);
                return Ok(new { Result = "Product is been added successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("add product request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }




        //UpdateProduct
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                _logger.LogInformation("update product request is recevied");
                _productService.UpdateProduct(product);
                _logger.LogInformation("Updated product: {Id}", product.id);
                return Ok(new { Result = "Product is been updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("update product request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }


        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _logger.LogInformation("delete product request is recevied");
                _productService.DeleteProduct(id);
                _logger.LogInformation("Deleted product: {Id}", id);
                return Ok(new { Result = "Product is been deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete product request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }
        //GetAllProducts
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                _logger.LogInformation("get all product request is recevied");
                var products = _productService.GetAllProducts();
                _logger.LogInformation("Retrieved all products");
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get all products occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }
    }
}

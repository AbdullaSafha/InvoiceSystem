using InvoiceSystem.Models;
using InvoiceSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly ILogger<ProductController> _logger;
       
        public CategoryController(CategoryService categoryService, ILogger<ProductController> logger)
        {

            _categoryService = categoryService;
            _logger = logger;
        }
        //Add product
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            _logger.LogWarning("Add category request receivied");
            _categoryService.AddCategory(category);
            _logger.LogWarning("Catgeory is added");
            return Ok();
        }
        //UpdateProduct
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            _categoryService.UpdateCategory(category);
            return Ok(new { Result = "Category is been updated successfully" });
        }
        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok(new { Result = "Category is been deleted successfully" });
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryService.GetCategory(id);
            return Ok(category);
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }
        
        
    }
}

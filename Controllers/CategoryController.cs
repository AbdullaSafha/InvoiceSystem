using InvoiceSystem.Models;
using InvoiceSystem.Services;
using Microsoft.AspNetCore.Mvc;

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
            _categoryService.AddCategory(category);
            return Ok();
        }
        //UpdateProduct
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            _categoryService.UpdateCategory(category);
            return Ok();
        }
        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
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

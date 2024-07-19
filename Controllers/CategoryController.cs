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
        public IActionResult AddCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest("category cannot be empty");
                }
                if (category.name == null || category.description == null)
                {
                    return BadRequest("category fields are requiried");

                }
                _logger.LogWarning("Add category request receivied");
                _categoryService.AddCategory(category);
                _logger.LogWarning("Catgeory is added");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Add category request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }
        //UpdateProduct
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            try
            {
                _logger.LogWarning("update category request receivied");
                _categoryService.UpdateCategory(category);
                _logger.LogWarning("Catgeory is updated");
                return Ok(new { Result = "Category is been updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Update category request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }
        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _logger.LogWarning("delete category request receivied");
                _categoryService.DeleteCategory(id);
                _logger.LogWarning("Catgeory is been deleted");
                return Ok(new { Result = "Category is been deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete category request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            try
            {

                _logger.LogWarning("Get category request receivied");

                var category = _categoryService.GetCategory(id);
                _logger.LogWarning("Returned category details");
                return Ok(category);
            }
            catch (Exception ex) {
                _logger.LogError("Get category request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                _logger.LogWarning("Get all category request receivied");
                var categories = _categoryService.GetAllCategories();
                _logger.LogWarning("Returned category details");
                return Ok(categories);
            }
            catch (Exception ex) 
            {
                _logger.LogError("Get all categories request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }
    }
}

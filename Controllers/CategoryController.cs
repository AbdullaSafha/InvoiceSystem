using InvoiceSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
        //Add product
        //UpdateProduct
        //Delete
        //GetAllProducts
    }
}

using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

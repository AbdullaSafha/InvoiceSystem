using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

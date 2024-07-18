using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

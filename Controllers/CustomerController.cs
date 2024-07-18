using InvoiceSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }
        //Add
        //Update
        //Delete
        //Get customers
    }
}

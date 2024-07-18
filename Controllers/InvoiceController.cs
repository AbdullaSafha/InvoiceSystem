using InvoiceSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly InvoiceService _invoiceService;
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;

        public InvoiceController(InvoiceService invoiceService, CustomerService customerService, ProductService productService)
        {
            _invoiceService = invoiceService;
            _customerService = customerService;
            _productService = productService;
        }

        //Generate Invoice
        
    }
}

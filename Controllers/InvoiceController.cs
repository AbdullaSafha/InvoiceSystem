using InvoiceSystem.Models;
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
        [HttpPost]
        public IActionResult GenerateInvoice([FromBody] Invoice invoice)
        {
            var customer = _customerService.GetCustomer(invoice.customer.id);
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            var items = new List<InvoiceItem>();
            foreach (var item in invoice.Items)
            {
                var product = _productService.GetProduct(item.ProductId);
                if (product == null || product.quantity < item.Quantity)
                {
                    return BadRequest("Invalid product or insufficient quantity.");
                }

                items.Add(new InvoiceItem
                {
                    ProductId = item.ProductId,
                    Product = product,
                    Quantity = item.Quantity,
                    TotalPrice = product.price * item.Quantity
                });

                product.quantity -= item.Quantity;
            }

            var generatedInvoice = _invoiceService.GenerateInvoice(customer , items, invoice.PaymentOption);
            return Ok(generatedInvoice);
        }

        [HttpGet("{id}")]
        public IActionResult GetInvoice(int id)
        {
            var invoice = _invoiceService.GetInvoice(id);
            return Ok(invoice);
        }

        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var invoices = _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

    }
}

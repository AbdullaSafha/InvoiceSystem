using InvoiceSystem.Models;
using InvoiceSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(CustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }
        //Add
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest("Customer details cannot be empty");
                }
                _logger.LogWarning("Add customer request receivied");
                _customerService.AddCustomer(customer);
                _logger.LogWarning("Catgeory is added");
                return Ok(new { Result = "Customer is been added successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Add customer request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }
        //Update
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                _logger.LogWarning("update customer request receivied");
                _customerService.UpdateCustomer(customer);
                _logger.LogWarning("updated customer details");
                return Ok(new { Result = "Customer is been updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Update customer request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
            }
        //Delete

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _logger.LogWarning("delete customer request receivied");
                _customerService.DeleteCustomer(id);
                _logger.LogWarning("deleted customer details");
                return Ok(new { Result = "Customer is been deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete customer request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }
        //Get customers
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                _logger.LogWarning("Get all customer request receivied");
                var customers = _customerService.GetAllCustomers();
                _logger.LogWarning("returned customer details");
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get all customer request occured error");

                _logger.LogInformation(ex.InnerException.ToString());

                throw ex;
            }
        }
    }
}


using InvoiceSystem.DataAccess;
using InvoiceSystem.Models;

namespace InvoiceSystem.Services
{
    public class CustomerService
    {
        private readonly string _filePath = "customer.json";
        private int _nextId;
        private readonly List<Customer> _customer;
        private readonly JsonHandler _fileHandler;


        public CustomerService(JsonHandler fileHandler)
        {
            _fileHandler = fileHandler;

            _customer = _fileHandler.ReadFromFile<Customer>(_filePath);
            _nextId = _customer.Any() ? _customer.Max(p => p.id) + 1 : 1;
        }

        internal void AddCustomer(Customer customer)
        {
            customer.id = _nextId;
            _customer.Add(customer);
            _fileHandler.WriteToFile(_filePath, _customer);
            _nextId++;
        }

        internal void DeleteCustomer(int id)
        {
            var customer = _customer.FirstOrDefault(p => p.id == id);
            if (customer != null)
            {
                _customer.Remove(customer);
                _fileHandler.WriteToFile(_filePath, _customer);
            }
        }

        internal object GetAllCustomers()
        {
            return _customer;
        }

        internal void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _customer.FirstOrDefault(c => c.id == customer.id);
            if (existingCustomer != null)
            {
                existingCustomer.name = customer.name;
                existingCustomer.email = customer.email;
                existingCustomer.contactNumber = customer.contactNumber;
                existingCustomer.address = customer.address;
                _fileHandler.WriteToFile(_filePath, _customer);
            }
        }
    }
}

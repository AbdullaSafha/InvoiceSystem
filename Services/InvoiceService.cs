
using InvoiceSystem.DataAccess;
using InvoiceSystem.Models;

namespace InvoiceSystem.Services
{
    public class InvoiceService
    {
        private readonly List<Invoice> _invoices = new List<Invoice>();
        private int _nextId = 1;
        private readonly string _filePath = "invoice.json";
        private readonly JsonHandler _fileHandler;

        public InvoiceService(JsonHandler fileHandler)
        {
            _fileHandler = fileHandler;
            _invoices = _fileHandler.ReadFromFile<Invoice>(_filePath);
            _nextId = _invoices.Any() ? _invoices.Max(p => p.id) + 1 : 1;
        }

        internal object GenerateInvoice(Customer customer, List<InvoiceItem> items, string paymentOption)
        {
            var invoice = new Invoice
            {
                id = _nextId++,
                customer = customer,
                Items = items,
                PaymentOption = paymentOption,
                TotalAmount = items.Sum(item => item.TotalPrice)
            };

            _invoices.Add(invoice);
            return invoice;
        }

        internal object GetAllInvoices()
        {
            return _invoices;
        }

        internal object GetInvoice(int id)
        {
            return _invoices.FirstOrDefault(i => i.id == id);
        }
    }
}

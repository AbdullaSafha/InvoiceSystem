using InvoiceSystem.Models;

namespace InvoiceSystem.Interfaces
{
    public interface IInvoice
    {
        int id { get; set; }
        ICustomer customer { get; set; }
        List<IProduct> products { get; set; }
        List<InvoiceItem> items { get; set; }
        decimal totalAmount { get; set; }

        string paymentOption { get; set; }

        void calculateTotalAmount();
    }
}

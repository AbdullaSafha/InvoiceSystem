namespace InvoiceSystem.Models
{
    public class Invoice
    {
        public int id { get; set; }
        public Customer customer { get; set; }
        public decimal totalAmount { get; set; }

        public List<InvoiceItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentOption { get; set; }
    }
}

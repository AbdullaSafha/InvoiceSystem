namespace InvoiceSystem.Models
{
    public class Invoice
    {
        public int id { get; set; }
        public Customer customer { get; set; }
        public decimal totalAmount { get; set; }

        public Invoice(int id, Customer customer, decimal totalAmount)
        {
            this.id = id;
            this.customer = customer;
            this.totalAmount = totalAmount;
        }
    }
}

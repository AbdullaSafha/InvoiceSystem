namespace InvoiceSystem.Interfaces
{
    public interface IProduct
    {
        int id { get; set; }
        string name { get; set; }
        string description { get; set; }
        decimal price { get; set; }
        int quantity { get; set; }
        ICategory category { get; set; }
    }
}

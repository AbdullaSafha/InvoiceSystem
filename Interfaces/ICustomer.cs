namespace InvoiceSystem.Interfaces
{
    public interface ICustomer
    {
        int id { get; set; }
        string name { get; set; }
        string email { get; set; }
        string address { get; set; }
        string contactNumber { get; set; }
    }
}

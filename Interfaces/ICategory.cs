using InvoiceSystem.Models;

namespace InvoiceSystem.Interfaces
{
    public interface ICategory
    {
        int id { get; set; }
        string name { get; set; }
        string description { get; set; }
    }
}

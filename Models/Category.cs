namespace InvoiceSystem.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public Category(int _id, string _name, string _description)
        {
            id = _id;
            name = _name;
            description = _description;
        }

    }
}

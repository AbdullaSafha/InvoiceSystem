namespace InvoiceSystem.Models
{
    public class Product
    {
        //as name, description, price, quantity, and category.
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public Category category { get; set; }

        public Product(int _id, 
            string _name,
            string _description,
            decimal _price,
            int _quantity,
            Category _category)
        {
            id = _id;
            price = _price;
            quantity = _quantity;
            name = _name;
            description = _description;
            category = _category;
        }
    }
}

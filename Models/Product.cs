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

        public Product(int id, 
            string name,
            string description,
            decimal price,
            int quantity,
            Category category)
        {
            this.id = id;
            this.price = price;
            this.quantity = quantity;
            this.name = name;
            this.description = description;
            this.category = category;
        }
    }
}

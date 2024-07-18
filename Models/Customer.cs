namespace InvoiceSystem.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string contactNumber { get; set; }

        public Customer(int id, string name, string email, string address, string contactNumber)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.address = address;
            this.contactNumber = contactNumber;
        }
    }
}

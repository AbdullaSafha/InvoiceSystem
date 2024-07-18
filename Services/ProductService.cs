
using InvoiceSystem.DataAccess;
using InvoiceSystem.Models;

namespace InvoiceSystem.Services
{
    public class ProductService
    {
        private readonly string _filePath = "products.json";
        private int _nextId;
        private readonly List<Product> _products;
        private readonly JsonHandler _fileHandler;

        public ProductService(JsonHandler fileHandler)
        {
            _fileHandler = fileHandler;
            _products = _fileHandler.ReadFromFile<Product>(_filePath);
            _nextId = _products.Any() ? _products.Max(p => p.id) + 1 : 1;
        }

        internal void AddProduct(Product product)
        {
            product.id = _nextId;
            _products.Add(product);
            _fileHandler.WriteToFile(_filePath, _products);
            _nextId++;
        }

        internal void UpdateProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.id == product.id);
            if (existingProduct != null)
            {
                existingProduct.name = product.name;
                existingProduct.description = product.description;
                existingProduct.price = product.price;
                existingProduct.quantity = product.quantity;
                //existingProduct.categoryId = product.categoryId;
                _fileHandler.WriteToFile(_filePath, _products);
            }
        }

        internal List<Product> GetAllProducts()
        {
            return _products;
        }

        internal void DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.id == id);
            if (product != null)
            {
                _products.Remove(product);
                _fileHandler.WriteToFile(_filePath, _products);
            }
            //throw new NotImplementedException();
        }
    }
}

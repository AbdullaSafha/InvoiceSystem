using InvoiceSystem.DataAccess;
using InvoiceSystem.Models;

namespace InvoiceSystem.Services
{
    public class CategoryService
    {

        private readonly string _filePath = "category.json";
        private int _nextId;
        private readonly JsonHandler _fileHandler;

        private readonly List<Category> _categories = new List<Category>();

        public CategoryService(JsonHandler fileHandler)
        {
            _fileHandler = fileHandler;

            _categories = _fileHandler.ReadFromFile<Category>(_filePath);
            _nextId = _categories.Any() ? _categories.Max(p => p.id) + 1 : 1;
        }
        internal void AddCategory(Category category)
        {
            category.id = _nextId++;
            _categories.Add(category);
        }

        internal void DeleteCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.id == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }

        internal object GetAllCategories()
        {
            return _categories;
        }

        internal object GetCategory(int id)
        {
            return _categories.FirstOrDefault(c => c.id == id);
        }

        internal void UpdateCategory(Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.id == category.id);
            if (existingCategory != null)
            {
                existingCategory.name = category.name;
                existingCategory.description = category.description;
            }
        }
    }
}

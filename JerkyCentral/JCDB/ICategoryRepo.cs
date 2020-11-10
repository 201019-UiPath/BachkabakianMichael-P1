using System.Collections.Generic;
using JCDB.Models;

namespace JCDB
{
    /// <summary>
    /// Data access interface for product categories
    /// </summary>
    public interface ICategoryRepo
    {
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        Category GetCategoryById(int id);
        Category GetCategoryByName(string name);
        List<Category> GetAllCategories();
    }
}
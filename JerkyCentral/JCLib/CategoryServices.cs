using JCDB;
using JCDB.Models;
using System.Collections.Generic;

namespace JCLib
{
    /// <summary>
    /// These Are The Methods That Connect With The DBRepo and Allow Me To Use My Category Related Business Logic Like Adding Updating Deleting Or Getting Categories
    /// </summary>
    public class CategoryServices
    {
        private ICategoryRepo repo;

        public CategoryServices(ICategoryRepo repo)
        {
            this.repo = repo;
        }
        public void AddCategory(Category category)
        {
            repo.AddCategory(category);
        }
        public void UpdateCategory(Category category)
        {
            repo.UpdateCategory(category);
        }
        public void DeleteCategory(Category category)
        {
            repo.DeleteCategory(category);
        }
        public Category GetCategoryById(int id)
        {
            Category category = repo.GetCategoryById(id);
            return category;
        }
        public Category GetCategoryByName(string name)
        {
            Category category = repo.GetCategoryByName(name);
            return category;
        }
        public List<Category> GetAllCategories()
        {
            List<Category> categories = repo.GetAllCategories();
            return categories;
        }
    }
}
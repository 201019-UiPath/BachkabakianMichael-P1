using System.Collections.Generic;
using JCDB.Models;

namespace JCDB
{
    /// <summary>
    /// Data access interface for JerkyCentral products
    /// </summary>
    public interface IProductRepo
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductById(int id);
        Product GetProductByName(string name);
        List<Product> GetAllProducts();
    }
}
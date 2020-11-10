using System.Collections.Generic;

namespace JCDB.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public string ShelfLife { get; set; }

        public List <Product> Products { get; set; }
    }
}
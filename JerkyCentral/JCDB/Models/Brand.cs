using System.Collections.Generic;

namespace JCDB.Models
{
    public class Brand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public List <Product> Products { get; set; }
    }
}
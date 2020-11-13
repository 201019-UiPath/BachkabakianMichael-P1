using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JerkyCentralWeb.Models
{
    public class Brand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public List<Product> Products { get; set; }
    }
}

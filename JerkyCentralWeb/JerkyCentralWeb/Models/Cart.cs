using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JerkyCentralWeb.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public int UserId { get; set; }

        public User user { get; set; }

        public List<CartLine> CartLines { get; set; }
    }
}

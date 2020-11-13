using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JerkyCentralWeb.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public double OrderTotal { get; set; }

        public int UserId { get; set; }

        public int LocationId { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderLine> OrderLine { get; set; }
    }
}

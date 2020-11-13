﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JerkyCentralWeb.Models
{
    public class OrderLine
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}

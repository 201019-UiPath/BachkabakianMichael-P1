﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JerkyCentralWeb.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PassWord { get; set; }

        public Cart cart { get; set; }

        public List<Order> Order { get; set; }
    }
}

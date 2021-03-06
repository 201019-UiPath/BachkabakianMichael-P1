﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JerkyCentralWeb.Models
{
    public class User
    {
        public int UserID { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [Required]
        public string PassWord { get; set; }

        public Cart cart { get; set; }

        public List<Order> Order { get; set; }
    }
}

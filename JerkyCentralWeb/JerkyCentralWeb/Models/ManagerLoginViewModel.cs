using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JerkyCentralWeb.Models
{
    public class ManagerLoginViewModel
    {
        [DataType(DataType.Text)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string PassWord { get; set; }
    }
}

using System.Collections.Generic;

namespace JCDB.Models
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
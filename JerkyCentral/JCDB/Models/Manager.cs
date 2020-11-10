
namespace JCDB.Models
{
    public class Manager
    {
        public int ManagerID { get; set; }

        public string Name { get; set; }

        public string PassWord { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }
    }
}
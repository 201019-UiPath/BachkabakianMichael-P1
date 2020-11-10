using System.Collections.Generic;
using JCDB.Models;

namespace JCDB
{
    /// <summary>
    /// Data acces interface for Jerky Central managers
    /// </summary>
    public interface IManagerRepo
    {
        void AddManager(Manager manager);
        void UpdateManager(Manager manager);
        void DeleteManager(Manager manager);
        Manager GetManagerById(int id);
        Manager GetManagerByName(string name);
        List<Manager> GetAllManagers();
    }
}
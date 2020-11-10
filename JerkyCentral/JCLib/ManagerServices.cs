using JCDB;
using JCDB.Models;
using System.Collections.Generic;

namespace JCLib
{
    /// <summary>
    /// These Are The Methods That Connect With The DBRepo and Allow Me To Use My Manager Related Business Logic Like Adding Updating Deleting Or Getting Managers
    /// </summary>
    public class ManagerServices
    {
        private IManagerRepo repo;

        public ManagerServices(IManagerRepo repo) 
        {
            this.repo = repo;
        }
        public void AddManager(Manager Manager)
        {
            repo.AddManager(Manager);
        }
        public void UpdateManager(Manager Manager)
        {
            repo.UpdateManager(Manager);
        }
        public void DeleteManager(Manager Manager)
        {
            repo.DeleteManager(Manager);
        }
        public Manager GetManagerById(int id)
        {
            Manager Manager = repo.GetManagerById(id);
            return Manager;
        }
        public Manager GetManagerByName(string name)
        {
            Manager Manager = repo.GetManagerByName(name);
            return Manager;
        }
        public List<Manager> GetAllManagers()
        {
            List<Manager> managers = repo.GetAllManagers();
            return managers;
        }
    }
}
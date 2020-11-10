using JCDB;
using JCDB.Models;
using System.Collections.Generic;

namespace JCLib
{
    public class UserServices
    {
        /// <summary>
        /// These Are The Methods That Connect With The DBRepo and Allow Me To Use My User Related Business Logic Like Adding Updating Deleting Or Getting Users
        /// </summary>
        private IUserRepo repo;

        public UserServices(IUserRepo repo) 
        {
            this.repo = repo;
        }
        public void AddUser(User user)
        {
            repo.AddUser(user);
        }
        public void UpdateUser(User user)
        {
            repo.UpdateUser(user);
        }
        public void DeleteUser(User user)
        {
            repo.DeleteUser(user);
        }
        public User GetUserById(int id)
        {
            User user = repo.GetUserById(id);
            return user;
        }
        public User GetUserByName(string name)
        {
            User user = repo.GetUserByName(name);
            return user;
        }
        public List<User> GetAllUsers()
        {
            List<User> users = repo.GetAllUsers();
            return users;
        }
    }
}
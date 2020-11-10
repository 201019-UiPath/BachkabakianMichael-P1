using System.Collections.Generic;
using JCDB.Models;

namespace JCDB
{
    /// <summary>
    /// Data access interface for JerkyCentral users
    /// </summary>
    public interface IUserRepo
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        User GetUserById(int id);
        User GetUserByName(string name);
        List<User> GetAllUsers();
    }
}
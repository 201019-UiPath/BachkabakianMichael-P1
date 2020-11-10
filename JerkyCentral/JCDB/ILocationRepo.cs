using System.Collections.Generic;
using JCDB.Models;

namespace JCDB
{
    /// <summary>
    /// Data access interface for JerkyCentral locations
    /// </summary>
    public interface ILocationRepo
    {
        void AddLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(Location location);
        Location GetLocationById(int id);
        Location GetLocationByName(string name);
        List<Location> GetAllLocations();
    }
}
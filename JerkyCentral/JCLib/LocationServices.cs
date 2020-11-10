using JCDB;
using JCDB.Models;
using System.Collections.Generic;

namespace JCLib
{
    /// <summary>
    /// These Are The Methods That Connect With The DBRepo and Allow Me To Use My Location Related Business Logic Like Adding Updating Deleting Or Getting Locations
    /// </summary>
    public class LocationServices
    {
        private ILocationRepo repo;

        public LocationServices(ILocationRepo repo)
        {
            this.repo = repo;
        }
        public void AddLocation(Location location)
        {
            repo.AddLocation(location);
        }
        public void UpdateLocation(Location location)
        {
            repo.UpdateLocation(location);
        }
        public void DeleteLocation(Location location)
        {
            repo.DeleteLocation(location);
        }
        public Location GetLocationById(int id)
        {
            Location location = repo.GetLocationById(id);
            return location;
        }
        public Location GetLocationByName(string name)
        {
            Location location = repo.GetLocationByName(name);
            return location;
        }
        public List<Location> GetAllLocations()
        {
            List<Location> locations = repo.GetAllLocations();
            return locations;
        }
    }
}
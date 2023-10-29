using System.Collections.Generic;
using XtramilePractical.Models;

namespace XtramilePractical.Services
{
    public class LocationService : ILocationService
    {
        public List<LocationModel> GetAllCountry()
        {
            List<LocationModel> locations = new List<LocationModel>
            {
                new LocationModel("Indonesia", "Jakarta"), 
                new LocationModel("Indonesia", "Bandung"), 
                new LocationModel("Indonesia", "Surabaya"), 
                new LocationModel("Japan", "Tokyo"), 
                new LocationModel("Japan", "Kyoto"), 
                new LocationModel("Japan", "Osaka"), 
                new LocationModel("Korea", "Seoul"), 
                new LocationModel("Korea", "Busan"), 
                new LocationModel("Korea", "Incheon") 
            };

            return locations;
        }
    }
}

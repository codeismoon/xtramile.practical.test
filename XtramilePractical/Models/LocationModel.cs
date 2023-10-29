namespace XtramilePractical.Models
{
    public class LocationModel
    {
        public string Country { get; set; }
        public string City { get; set; }

        public LocationModel(string country, string city)
        {
            Country = country;
            City = city;
        }
    }
}

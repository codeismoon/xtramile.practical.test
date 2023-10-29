using Newtonsoft.Json;

namespace XtramilePractical.Models
{
    public class WeatherResponseModel
    {
        public string Location { get; set; }
        public string Time { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyCondition { get; set; }
        public string TemperatureCelsius { get; set; }
        [JsonProperty("temperature")]
        public string TemperatureFahrenheit { get; set; }
        public string DewPoint { get; set; }
        public string RelativeHumidity { get; set; }
        public string Pressure { get; set; }
    }
}

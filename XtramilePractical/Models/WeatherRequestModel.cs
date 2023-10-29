using Newtonsoft.Json;

namespace XtramilePractical.Models
{
    public class WeatherRequestModel
    {
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("wind")]
        public string Wind { get; set; }
        [JsonProperty("visibility")]
        public string Visibility { get; set; }
        [JsonProperty("skycondition")]
        public string SkyCondition { get; set; }
        [JsonProperty("temperature")]
        public string Temperature { get; set; }
        [JsonProperty("dewpoint")]
        public string DewPoint { get; set; }
        [JsonProperty("relativehumidity")]
        public string RelativeHumidity { get; set; }
        [JsonProperty("pressure")]
        public string Pressure { get; set; }
    }
}
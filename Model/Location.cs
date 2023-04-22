using System.Text.Json.Serialization;

namespace WeatherFlex.Model
{
    public class LocationDataWrapper
    {
        [JsonPropertyName("features")]
        public List<FeatureProperties> Features { get; set; }
    }

    public class FeatureProperties
    {
        [JsonPropertyName("properties")]
        public LocationData LocationData { get; set; }
    }

    public class LocationData
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}

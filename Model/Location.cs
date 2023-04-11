using System.Text.Json.Serialization;

namespace WeatherFlex.Model
{
    public class LocationFeatures
    {
        [JsonPropertyName("features")]
        public List<LocationFeature> Features { get; set; }
    }

    public class LocationFeature
    {
        [JsonPropertyName("properties")]
        public LocationProperties LocationProperties { get; set; }
    }

    public class LocationProperties
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

    }
}

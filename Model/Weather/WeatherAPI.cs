using System.Text.Json.Serialization;

namespace WeatherFlex.Model.Weather
{
    public class WeatherAPI
    {
        [JsonIgnore]
        public LocationProperties LocationProperties { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("current_weather")]
        public Weather CurrentWeather { get; set; }

        [JsonPropertyName("hourly_units")]
        public HourlyUnits HourlyUnits { get; set; }

        [JsonPropertyName("hourly")]
        public TemperatureForecast TemperatureForecast { get; set; }
    }
}

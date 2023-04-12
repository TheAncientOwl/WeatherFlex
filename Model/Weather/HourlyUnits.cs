using System.Text.Json.Serialization;

namespace WeatherFlex.Model.Weather
{
    public class HourlyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string Units { get; set; }
    }
}

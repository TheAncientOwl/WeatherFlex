using System.Text.Json.Serialization;

namespace WeatherFlex.Model.Weather
{
    public class DailyForecast
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("weathercode")]
        public List<int> Weathercode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double> TemperatureMax2m { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double> TemperatureMin2m { get; set; }

        [JsonPropertyName("sunrise")]
        public List<string> Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public List<string> Sunset { get; set; }

        [JsonPropertyName("precipitation_probability_max")]
        public List<int?> PrecipitationProbability { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace WeatherFlex.Model
{
    public class WeatherAPI
    {
        [JsonIgnore]
        public LocationProperties LocationProperties { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("current_weather")]
        public Weather CurrentWeather { get; set; }

        [JsonPropertyName("hourly_units")]
        public HourlyUnits HourlyUnits { get; set; }

        [JsonPropertyName("hourly")]
        public HourlyTemperature HourlyTemperature { get; set; }
    }

    public class HourlyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string Units { get; set; }
    }

    public class HourlyTemperature
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature { get; set; }

        [JsonPropertyName("is_day")]
        public List<int> IsDay { get; set; }

        [JsonPropertyName("precipitation_probability")]
        public List<int> PrecipitationProbability { get; set; }

        [JsonPropertyName("weathercode")]
        public List<int> Weathercode { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("windspeed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("weathercode")]
        public int Weathercode { get; set; }
    }

    public class Weathercodes
    {
        public static Dictionary<int, string> Dictionary { get; } = new Dictionary<int, string>()
        {
            { 0, "clear sky" },
            { 1, "mainly clear" },
            { 2, "partly cloudy" },
            { 3, "overcast" },
            { 45, "fog" },
            { 48, "rime fog" },
            { 51, "light drizzle" },
            { 53, "moderate drizzle" },
            { 55, "dense drizzle" },
            { 56, "light freezing drizzle" },
            { 57, "dense freezing drizzle" },
            { 61, "slight rain" },
            { 63, "moderate rain" },
            { 65, "heavy rain" },
            { 66, "light freezing rain" },
            { 67, "heavy freezing rain" },
            { 71, "slight snow fall" },
            { 73, "moderate snow fall" },
            { 75, "heavy snow fall" },
            { 77, "snow grains" },
            { 80, "slight rain showers" },
            { 81, "moderate rain showers" },
            { 82, "heavy rain showers" },
            { 85, "slight snow showers" },
            { 86, "heavy snow showers" },
            { 95, "thunderstorm" },
            { 96, "thunderstorm with slight hail" },
            { 99, "thunderstorm with heavy hail" }
        };
    }
}

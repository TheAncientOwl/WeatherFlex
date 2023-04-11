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

        [JsonIgnore]
        public string WeatherInterpretation { get => Weathercodes.Dictionary[Weathercode]; }
    }

    public class Weathercodes
    {
        public static Dictionary<int, string> Dictionary { get; } = new Dictionary<int, string>()
        {
            { 0, "Clear sky" },
            { 1, "Mainly clear" },
            { 2, "Partly cloudy" },
            { 3, "Overcast" },
            { 45, "Fog" },
            { 48, "Rime fog" },
            { 51, "Light drizzle" },
            { 53, "Moderate drizzle" },
            { 55, "Dense drizzle" },
            { 56, "Light freezing drizzle" },
            { 57, "Dense freezing drizzle" },
            { 61, "Slight rain" },
            { 63, "Moderate rain" },
            { 65, "Heavy rain" },
            { 66, "Light freezing rain" },
            { 67, "Heavy freezing rain" },
            { 71, "Slight snow fall" },
            { 73, "Moderate snow fall" },
            { 75, "Heavy snow fall" },
            { 77, "Snow grains" },
            { 80, "Slight rain showers" },
            { 81, "Moderate rain showers" },
            { 82, "Heavy rain showers" },
            { 85, "Slight snow showers" },
            { 86, "Heavy snow showers" },
            { 95, "Thunderstorm" },
            { 96, "Thunderstorm with slight hail" },
            { 99, "Thunderstorm with heavy hail" }
        };
    }
}

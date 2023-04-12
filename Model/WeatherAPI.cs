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

    public class Temperature
    {
        public string Time { get; set; }
        public double Value { get; set; }
        public string Units { get; set; }
        public int PrecipitationProbability { get; set; }
        public Weathercode Weathercode { get; set; }
        public string Hour { get => Time.Split('T')[1]; }
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
        public string WeatherInterpretation { get; set; }
    }

    public class Weathercode
    {
        public string Interpretation { get; private set; }
        public Color BackgroundColor { get; private set; }
        public Color TextColor { get; private set; }

        private Weathercode(string interpretation, Color backgroundColor, Color textColor)
        {
            Interpretation = interpretation;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
        }

        public static Weathercode FromCode(int code)
        {
            try
            {
                return Dictionary[code];
            }
            catch
            {
                return new Weathercode("Unknown", Colors.LightSkyBlue, Colors.DimGray);
            }
        }

        private static readonly Dictionary<int, Weathercode> Dictionary = new(28)
        {
            { 0,  new Weathercode("Clear sky", Colors.LightSkyBlue, Colors.DimGray) },
            { 1,  new Weathercode("Mainly clear", Colors.LightSkyBlue, Colors.DimGray) },
            { 2,  new Weathercode("Partly cloudy", Colors.LightSkyBlue, Colors.DimGray) },
            { 3,  new Weathercode("Overcast", Colors.LightSkyBlue, Colors.DimGray) },
            { 45, new Weathercode("Fog", Colors.LightSkyBlue, Colors.DimGray) },
            { 48, new Weathercode("Rime fog", Colors.LightSkyBlue, Colors.DimGray) },
            { 51, new Weathercode("Light drizzle", Colors.LightSkyBlue, Colors.DimGray) },
            { 53, new Weathercode("Moderate drizzle", Colors.LightSkyBlue, Colors.DimGray) },
            { 55, new Weathercode("Dense drizzle", Colors.LightSkyBlue, Colors.DimGray) },
            { 56, new Weathercode("Light freezing drizzle", Colors.LightSkyBlue, Colors.DimGray) },
            { 57, new Weathercode("Dense freezing drizzle", Colors.LightSkyBlue, Colors.DimGray) },
            { 61, new Weathercode("Slight rain", Colors.LightSkyBlue, Colors.DimGray) },
            { 63, new Weathercode("Moderate rain", Colors.LightSkyBlue, Colors.DimGray) },
            { 65, new Weathercode("Heavy rain", Colors.LightSkyBlue, Colors.DimGray) },
            { 66, new Weathercode("Light freezing rain", Colors.LightSkyBlue, Colors.DimGray) },
            { 67, new Weathercode("Heavy freezing rain", Colors.LightSkyBlue, Colors.DimGray) },
            { 71, new Weathercode("Slight snow fall", Colors.LightSkyBlue, Colors.DimGray) },
            { 73, new Weathercode("Moderate snow fall", Colors.LightSkyBlue, Colors.DimGray) },
            { 75, new Weathercode("Heavy snow fall", Colors.LightSkyBlue, Colors.DimGray) },
            { 77, new Weathercode("Snow grains", Colors.LightSkyBlue, Colors.DimGray) },
            { 80, new Weathercode("Slight rain showers", Colors.LightSkyBlue, Colors.DimGray) },
            { 81, new Weathercode("Moderate rain showers", Colors.LightSkyBlue, Colors.DimGray) },
            { 82, new Weathercode("Heavy rain showers", Colors.LightSkyBlue, Colors.DimGray) },
            { 85, new Weathercode("Slight snow showers", Colors.LightSkyBlue, Colors.DimGray) },
            { 86, new Weathercode("Heavy snow showers", Colors.LightSkyBlue, Colors.DimGray) },
            { 95, new Weathercode("Thunderstorm", Colors.LightSkyBlue, Colors.DimGray) },
            { 96, new Weathercode("Thunderstorm with slight hail", Colors.LightSkyBlue, Colors.DimGray) },
            { 99, new Weathercode("Thunderstorm with heavy hail", Colors.LightSkyBlue, Colors.DimGray) }
        };
    }
}

using System.Text.Json.Serialization;
using WeatherFlex.Model.Weather;

namespace WeatherFlex.Model
{
    public class WeatherForecast
    {
        [JsonIgnore]
        public LocationProperties LocationProperties { get; set; }
        [JsonIgnore]
        public string WeatherInterpretation { get; set; }
        [JsonIgnore]
        public Color BackgroundColor { get; private set; }
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("elevation")]
        public double Elevation { get; set; }

        [JsonPropertyName("daily_units")]
        public ForecastDailyUnits DailyUnits { get; set; }

        [JsonPropertyName("daily")]
        public ForecastDailyValues DailyValues { get; set; }
        public DailyForecast DailyForecast { get; set; }
    }
    
    public class ForecastDailyUnits
    {
        [JsonPropertyName("temperature_2m_max")]
        public string TemperatureMax2m { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public string TemperatureMin2m { get; set; }

        [JsonPropertyName("precipitation_probability_max")]
        public string PrecipitationProbability { get; set; }
    }

    public class ForecastDailyValues
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

    public class ForecastValues
    {
        public string Time { get; set; }
        public WeatherCode WeatherCode { get; set; }
        public double TemperatureMax2m { get; set; }
        public double TemperatureMin2m { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public int? PrecipitationProbability { get; set; }
        
        public string Units { get; set; }  
    }
    
}

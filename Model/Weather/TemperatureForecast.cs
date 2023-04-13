﻿using System.Text.Json.Serialization;

namespace WeatherFlex.Model.Weather
{
    public class TemperatureForecast
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature { get; set; }

        [JsonPropertyName("precipitation_probability")]
        public List<int> PrecipitationProbability { get; set; }

        [JsonPropertyName("weathercode")]
        public List<int> Weathercode { get; set; }

        public DateTime GetDateTimeAt(int index)
        {
            return DateTime.Parse(Time[index]);
        }
    }
}


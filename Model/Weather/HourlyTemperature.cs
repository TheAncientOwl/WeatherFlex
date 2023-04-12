﻿using System.Globalization;
using System.Text.Json.Serialization;

namespace WeatherFlex.Model.Weather
{
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

        public DateTime GetDateTimeAt(int index) =>
             DateTime.TryParseExact(Time[index], "yyyy-MM-ddThh:mm",
                                          CultureInfo.InvariantCulture, DateTimeStyles.None,
                                          out DateTime dateTime)
                ? dateTime
                : DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherFlex.Model.Weather
{
    public class TemperatureDaily
    {
        public string Time { get; set; }
        public double Value { get; set; }
        public string Units { get; set; }
        public bool IsNow { get; set; } = false;
        public int PrecipitationProbability { get; set; }
        public WeatherCode WeatherCode { get; set; }
        public string Daily { get => IsNow ? "Now" : Time.Split('T')[24]; }
    }
}

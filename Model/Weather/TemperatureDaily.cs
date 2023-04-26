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
        public WeatherCode weatherCode { get; set; }
        public string TemperatureMax2m { get; set; }
        public string TemperatureMin2m { get; set; }
        
        public string Sunrise{ get; set; }
        public string Sunset { get; set; }

        public int PrecipitationProbability { get; set; }
       
    }
}

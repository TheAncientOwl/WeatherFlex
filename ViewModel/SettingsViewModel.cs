using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherFlex.ViewModel
{
    public class SettingsViewModel
    {
        public bool PreffersCelsius
        {
            get
            {
                return false;
            }
        }

        public bool PreffersFahrenheit { get; }

    }
}

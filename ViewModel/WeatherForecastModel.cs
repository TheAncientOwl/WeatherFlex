using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherFlex.Model;
using WeatherFlex.Services;

namespace WeatherFlex.ViewModel
{
    public class WeatherForecastModel : INotifyPropertyChanged
    {
        private WeatherForecast weatherForecast;
        private double latitude;
        private double longitude;
        private DateTime startDate;
        private DateTime endDate;

        public event PropertyChangedEventHandler PropertyChanged;

        public WeatherForecast WeatherForecast
        {
            get => weatherForecast;
            set
            {
                weatherForecast = value;
                OnPropertyChanged();
            }
        }

        public List<DailyUnits> DailyWeatherUnit { get; set; }


        public WeatherForecastModel()
        {
            DailyWeatherUnit = new List<DailyUnits>();
            FetchWeatherForecast();
        }
        public WeatherForecastModel(double latitude, double longitude, DateTime startDate, DateTime endDate)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.startDate = startDate;
            this.endDate = endDate;

            FetchWeatherForecast();
        }

        private async void FetchWeatherForecast()
        {
            var weatherForecasts = await new WeatherServiceForecast().FetchWeather(latitude, longitude, startDate, endDate, "GMT");
            WeatherForecast = weatherForecast;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

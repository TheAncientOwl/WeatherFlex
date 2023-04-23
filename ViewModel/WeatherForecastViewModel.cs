using WeatherFlex.Model;
using WeatherFlex.Services;

namespace WeatherFlex.ViewModel
{
    public class WeatherForecastViewModel
    {
        public WeatherForecast WeatherForecast { get; set; }

        //public List<DailyUnits> DailyWeatherUnit { get; set; }

        //public WeatherForecastViewModel()
        //{
        //    DailyWeatherUnit = new List<DailyUnits>();
        //}

        public async Task FetchWeatherForecast(double latitude, double longitude)
        {
            WeatherForecast = await new WeatherForecastService().FetchWeather(latitude, longitude);
        }

    }
}

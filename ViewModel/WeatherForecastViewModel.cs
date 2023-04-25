using WeatherFlex.Data;
using WeatherFlex.Model;
using WeatherFlex.Model.Weather;
using WeatherFlex.Services;

namespace WeatherFlex.ViewModel
{
    public class WeatherForecastViewModel
    {
        public WeatherForecast WeatherForecast { get; set; }

        public async Task FetchWeatherForecast(double latitude, double longitude)
        {
            WeatherForecast = await new WeatherForecastService().FetchWeather(latitude, longitude);
        }
        public async Task GetUserWeatherAsync()
        {
            Location userLocation = await new GeolocationService().GetLocationAsync();

            await GetWeatherAsync(userLocation.Latitude, userLocation.Longitude);
        }
        public async Task GetWeatherAsync(double latitude, double longitude)
        {
            WeatherForecast = await WeatherForecastData.Get(latitude, longitude);
        }

        public List<ForecastValues> GetForecastValues()
        {
            List<ForecastValues> forecasts = new();

            var dailyValues = WeatherForecast.DailyValues;
            for (int i = 0; i < dailyValues.TemperatureMax2m.Count; i++)
            {
                forecasts.Add(new ForecastValues()
                {
                    Time = dailyValues.Time[i],
                    Weathercode = WeatherCode.FromCode(dailyValues.Weathercode[i]),
                    TemperatureMax2m = dailyValues.TemperatureMax2m[i],
                    TemperatureMin2m = dailyValues.TemperatureMin2m[i],
                    Sunrise = dailyValues.Sunrise[i],
                    Sunset = dailyValues.Sunset[i],
                    PrecipitationProbability = dailyValues.PrecipitationProbability[i]
                });
            }

            return forecasts;
        }
    }
}

//using AuthenticationServices;
using System;
using WeatherFlex.Data;
using WeatherFlex.Model;
using WeatherFlex.Model.Weather;
using WeatherFlex.Services;
using WeatherFlex.ViewModels;

namespace WeatherFlex.ViewModel
{
    public class WeatherForecastViewModel
    {
        public WeatherForecast WeatherForecast { get; private set; }


        //public string Timezone { get => WeatherForecast?.Timezone; }
        

        public LocationProperties LocationProperties { get => WeatherForecast.LocationProperties; }

        
        //public WeatherCode weatherCode { get => WeatherForecast.WeatherCode}
        public List<int> weatherCode { get => WeatherForecast.DailyForecast.Weathercode; }
        
        public async Task FetchWeatherForecast(double latitude, double longitude)
        {
            WeatherForecast = await new WeatherForecastService().FetchWeather(latitude, longitude);
            WeatherForecast.LocationProperties = await new GeolocationService().GetLocationPropertiesAsync(latitude, longitude);
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

        public List<ForecastValues> GetForecastValues(Settings userSettings)
        {
            List<ForecastValues> forecasts = new();

            var dailyValues = WeatherForecast.DailyValues;
            for (int i = 0; i < dailyValues.TemperatureMax2m.Count; i++)
            {
                var max = userSettings.PreffersCelsius ? dailyValues.TemperatureMax2m[i] : WeatherViewModel.ToFahrenheit(dailyValues.TemperatureMax2m[i]);
                var min = userSettings.PreffersCelsius ? dailyValues.TemperatureMin2m[i] : WeatherViewModel.ToFahrenheit(dailyValues.TemperatureMin2m[i]);
                var symbol = userSettings.PreffersCelsius ? "°C" : "°F";
                forecasts.Add(new ForecastValues()
                {
                    Time = dailyValues.Time[i],
                    WeatherCode = WeatherCode.FromCode(dailyValues.Weathercode[i]),
                    TemperatureMax2m = max, 
                    TemperatureMin2m = min,
                    Sunrise = dailyValues.Sunrise[i].Substring(dailyValues.Sunrise[i].Length-5),
                    Sunset = dailyValues.Sunset[i].Substring(dailyValues.Sunset[i].Length-5),
                    PrecipitationProbability = dailyValues.PrecipitationProbability[i] != null ? dailyValues.PrecipitationProbability[i] : 0,
                    Units = symbol
                });
            }

            return forecasts;
        }
        
    }
}

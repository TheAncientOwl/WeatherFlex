//using AuthenticationServices;
using System;
using WeatherFlex.Data;
using WeatherFlex.Model;
using WeatherFlex.Model.Weather;
using WeatherFlex.Services;

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

        public List<ForecastValues> GetForecastValues()
        {
            List<ForecastValues> forecasts = new();

            var dailyValues = WeatherForecast.DailyValues;
            for (int i = 0; i < dailyValues.TemperatureMax2m.Count; i++)
            {
                forecasts.Add(new ForecastValues()
                {
                    Time = dailyValues.Time[i],
                    WeatherCode = WeatherCode.FromCode(dailyValues.Weathercode[i]),
                    TemperatureMax2m = dailyValues.TemperatureMax2m[i],
                    TemperatureMin2m = dailyValues.TemperatureMin2m[i],
                    Sunrise = dailyValues.Sunrise[i].Substring(dailyValues.Sunrise[i].Length-5),
                    Sunset = dailyValues.Sunset[i].Substring(dailyValues.Sunset[i].Length-5),
                    PrecipitationProbability = dailyValues.PrecipitationProbability[i] != null ? dailyValues.PrecipitationProbability[i] : 0

            });
            }

            return forecasts;
        }
    }
}

using System.Net.Http.Json;
using WeatherFlex.Model.Weather;

namespace WeatherFlex.Services
{
    public class WeatherService
    {
        private class QueryParameters
        {
            public static readonly string Location = "&latitude={0}&longitude={1}";
            public static readonly string CurrentWeather = "&current_weather=true";
            public static readonly string Hourly = "&hourly=temperature_2m,is_day,precipitation_probability,weathercode";
            public static readonly string ForecastDays = "&forecast_days=2";
        }
        private static readonly string API_LINK = "https://api.open-meteo.com/v1/forecast?" + QueryParameters.Location + QueryParameters.CurrentWeather + QueryParameters.Hourly + QueryParameters.ForecastDays;

        readonly HttpClient httpClient;

        public WeatherService()
        {
            httpClient = new HttpClient();
        }

        public async Task<WeatherAPI> FetchWeather(double latitude, double longitude)
        {
            WeatherAPI weather = await httpClient.GetFromJsonAsync<WeatherAPI>(string.Format(API_LINK, latitude, longitude));

            return weather;
        }
    }
}

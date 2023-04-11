using System.Net.Http.Json;
using WeatherFlex.Model;

namespace WeatherFlex.Services
{
    public class WeatherService
    {
        private static readonly string API_PARAMETERS = "latitude={0}&longitude={1}&forecast_days=2&current_weather=true&hourly=temperature_2m";
        private static readonly string API_LINK = "https://api.open-meteo.com/v1/forecast?" + API_PARAMETERS;

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

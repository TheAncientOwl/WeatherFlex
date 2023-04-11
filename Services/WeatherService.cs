using System.Net.Http.Json;
using WeatherFlex.Model;

namespace WeatherFlex.Services
{
    public class WeatherService
    {
        private static readonly string API_LINK = "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&hourly=temperature_2m";

        readonly HttpClient httpClient;

        public WeatherService()
        {
            httpClient = new HttpClient();
        }

        public async Task<Weather> FetchWeather(double latitude, double longitude)
        {
            Weather weather = await httpClient.GetFromJsonAsync<Weather>(string.Format(API_LINK, latitude, longitude));

            return weather;
        }
    }
}

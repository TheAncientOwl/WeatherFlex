using System.Globalization;
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
            public static readonly string Hourly = "&hourly=temperature_2m,precipitation_probability,weathercode";
            public static readonly string ForecastDays = "&forecast_days=4";
        }
        private static readonly string API_LINK = "https://api.open-meteo.com/v1/forecast?" + QueryParameters.Location + QueryParameters.CurrentWeather + QueryParameters.Hourly + QueryParameters.ForecastDays;

        readonly HttpClient httpClient = new();

        public async Task<WeatherAPI> FetchWeather(double latitude, double longitude)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-US");

            var link = string.Format(
                API_LINK,
                ((float)latitude).ToString(cultureInfo),
                ((float)longitude).ToString(cultureInfo));

            try
            {
                return await httpClient.GetFromJsonAsync<WeatherAPI>(link);
            }
            catch
            {
                await Shell.Current.DisplayAlert("Internet error", "Check your internet connection", "OK");
                return null;
            }
        }
    }
}

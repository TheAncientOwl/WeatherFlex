using System.Globalization;
using System.Net.Http.Json;
using WeatherFlex.Model;

namespace WeatherFlex.Services
{
    public class WeatherForecastService
    {
        private class QueryParameters
        {
            public static readonly string Location = "&latitude={0}&longitude={1}";
            public static readonly string Daily = "&daily=weathercode,temperature_2m_max,temperature_2m_min,sunrise,sunset,precipitation_probability_max";
            public static readonly string ForecastDays = "&forecast_days=14";
            public static readonly string TimeZone = "&timezone=auto";
        }

        private static readonly string API_LINK = "https://api.open-meteo.com/v1/forecast?" + QueryParameters.Location + QueryParameters.Daily + QueryParameters.ForecastDays + QueryParameters.TimeZone;

        private readonly HttpClient httpClient;

        public WeatherForecastService()
        {
            httpClient = new HttpClient();
        }

        public async Task<WeatherForecast> FetchWeather(double latitude, double longitude)
        {
            var link = string.Format(API_LINK,
                ((float)latitude).ToString(CultureInfo.GetCultureInfo("en-US")),
                ((float)longitude).ToString(CultureInfo.GetCultureInfo("en-US"))
            );

            WeatherForecast weather = await httpClient.GetFromJsonAsync<WeatherForecast>(link);

            return weather;
        }
    }
}

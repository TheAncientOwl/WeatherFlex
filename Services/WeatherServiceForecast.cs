using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherFlex.Model;

namespace WeatherFlex.Services
{
    public class WeatherServiceForecast
    {
        private class QueryParameters
        {
            public static readonly string Location = "&latitude={0}&longitude={1}";
            public static readonly string Daily = "&daily=weathercode,temperature_2m_max,temperature_2m_min,sunrise,sunset,precipitation_probability_max";
            public static readonly string ForecastDays = "&forecast_days=14";
            public static readonly string StartDate = "&start_date={0}";
            public static readonly string EndDate = "&end_date={0}";
            public static readonly string TimeZone = "&timezone={0}";
        }

        private static readonly string API_LINK = "https://api.open-meteo.com/v1/forecast?" + QueryParameters.Location + QueryParameters.Daily + QueryParameters.ForecastDays + QueryParameters.StartDate + QueryParameters.EndDate + QueryParameters.TimeZone;

        private readonly HttpClient httpClient;

        public WeatherServiceForecast()
        {
            httpClient = new HttpClient();
        }

        public async Task<WeatherForecast> FetchWeather(double latitude, double longitude, DateTime startDate, DateTime endDate, string timezone)
        {
            var link = string.Format(API_LINK,
                ((float)latitude).ToString(CultureInfo.GetCultureInfo("en-US")),
                ((float)longitude).ToString(CultureInfo.GetCultureInfo("en-US")),
                startDate.ToString("yyyy-MM-dd"),
                endDate.ToString("yyyy-MM-dd"),
                timezone);

            WeatherForecast weather = await httpClient.GetFromJsonAsync<WeatherForecast>(link);

            return weather;
        }
    }
}

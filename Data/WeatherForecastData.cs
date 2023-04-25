using WeatherFlex.Model;
using WeatherFlex.Services;

namespace WeatherFlex.Data
{
    public class WeatherForecastData
    {
        readonly Dictionary<Tuple<double, double>, Tuple<WeatherForecast, DateTime>> data = new();

        static WeatherForecastData instance;

        static async Task<WeatherForecast> FetchWeather(double latitude, double longitude)
        {
            WeatherForecast weatherForecast = await new WeatherForecastService().FetchWeather(latitude, longitude);
            weatherForecast.LocationProperties = await new GeolocationService().GetLocationPropertiesAsync(latitude, longitude);

            return weatherForecast;
        }

        public static async Task<WeatherForecast> Get(double latitude, double longitude)
        {
            instance ??= new WeatherForecastData();

            Tuple<double, double> location = new(latitude, longitude);

            WeatherForecast weatheForecast;
            if (instance.data.TryGetValue(location, out Tuple<WeatherForecast, DateTime> dataValue))
            {
                TimeSpan timeSinceLastFetch = DateTime.Now - dataValue.Item2;

                if (timeSinceLastFetch.TotalMinutes < 5)
                {
                    weatheForecast = dataValue.Item1;
                }
                else
                {
                    weatheForecast = await FetchWeather(latitude, longitude);
                    instance.data[location] = new(weatheForecast, DateTime.Now);
                }
            }
            else
            {
                weatheForecast = await FetchWeather(latitude, longitude);
                instance.data.Add(location, new(weatheForecast, DateTime.Now));
            }

            return weatheForecast;
        }

        private WeatherForecastData() { }
    }
}

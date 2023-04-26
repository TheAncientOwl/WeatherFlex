using WeatherFlex.Model;
using WeatherFlex.Services;

namespace WeatherFlex.DataCache
{
    public class WeatherForecastDataCache
    {
        readonly Dictionary<Tuple<double, double>, Tuple<WeatherForecast, DateTime>> data = new();

        static WeatherForecastDataCache instance;

        static async Task<WeatherForecast> FetchWeather(double latitude, double longitude)
        {
            WeatherForecast weatherForecast = await new WeatherForecastService().FetchWeather(latitude, longitude);
            weatherForecast.LocationProperties = await new GeolocationService().GetLocationPropertiesAsync(latitude, longitude);

            return weatherForecast;
        }

        public static async Task<WeatherForecast> Get(double latitude, double longitude)
        {
            instance ??= new WeatherForecastDataCache();

            Tuple<double, double> location = new(latitude, longitude);

            WeatherForecast weatherForecast;
            if (instance.data.TryGetValue(location, out Tuple<WeatherForecast, DateTime> dataValue))
            {
                TimeSpan timeSinceLastFetch = DateTime.Now - dataValue.Item2;

                if (timeSinceLastFetch.TotalMinutes < 5)
                {
                    weatherForecast = dataValue.Item1;
                }
                else
                {
                    weatherForecast = await FetchWeather(latitude, longitude);
                    instance.data[location] = new(weatherForecast, DateTime.Now);
                }
            }
            else
            {
                weatherForecast = await FetchWeather(latitude, longitude);
                instance.data.Add(location, new(weatherForecast, DateTime.Now));
            }

            return weatherForecast;
        }

        private WeatherForecastDataCache() { }
    }
}

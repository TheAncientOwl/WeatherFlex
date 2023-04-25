using WeatherFlex.Database;
using WeatherFlex.Model;
using WeatherFlex.Model.Weather;
using WeatherFlex.Services;

namespace WeatherFlex.DataCache
{
    public class WeatherDataCache
    {
        readonly Dictionary<Tuple<double, double>, Tuple<WeatherAPI, DateTime>> data = new();

        static WeatherDataCache instance;

        static async Task<WeatherAPI> FetchWeather(double latitude, double longitude)
        {
            WeatherAPI weatherApi = await new WeatherService().FetchWeather(latitude, longitude);
            if (weatherApi != null)
            {
                weatherApi.LocationProperties = await new GeolocationService().GetLocationPropertiesAsync(latitude, longitude);
            }

            return weatherApi;
        }

        public static async Task<WeatherAPI> Get(double latitude, double longitude)
        {
            instance ??= new WeatherDataCache();

            Tuple<double, double> location = new(latitude, longitude);

            WeatherAPI weatherApi;
            if (instance.data.TryGetValue(location, out Tuple<WeatherAPI, DateTime> dataValue))
            {
                TimeSpan timeSinceLastFetch = DateTime.Now - dataValue.Item2;

                SettingsDao settingsDao = new();
                Settings settings = await settingsDao.Get();
                await settingsDao.CloseAsync();

                if (timeSinceLastFetch.TotalMinutes < settings.WeatherDelay)
                {
                    weatherApi = dataValue.Item1;
                }
                else
                {
                    weatherApi = await FetchWeather(latitude, longitude);
                    instance.data[location] = new(weatherApi, DateTime.Now);
                }
            }
            else
            {
                weatherApi = await FetchWeather(latitude, longitude);
                instance.data.Add(location, new(weatherApi, DateTime.Now));
            }

            return weatherApi;
        }

        private WeatherDataCache() { }
    }
}

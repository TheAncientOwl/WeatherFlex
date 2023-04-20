using WeatherFlex.Model.Weather;
using WeatherFlex.Services;

namespace WeatherFlex.Data
{
    public class WeatherData
    {
        readonly Dictionary<Tuple<double, double>, Tuple<WeatherAPI, DateTime>> data = new();

        static WeatherData instance;

        async Task<WeatherAPI> FetchWeather(double latitude, double longitude)
        {
            WeatherAPI weatherApi = await new WeatherService().FetchWeather(latitude, longitude);
            weatherApi.LocationProperties = await new GeolocationService().GetLocationPropertiesAsync(latitude, longitude);

            return weatherApi;
        }

        public static async Task<WeatherAPI> GetFor(double latitude, double longitude)
        {
            instance ??= new WeatherData();

            Tuple<double, double> location = new(latitude, longitude);

            WeatherAPI weatherApi;
            try
            {
                var weather = instance.data[location];

                TimeSpan timeSinceLastFetch = DateTime.Now - weather.Item2;

                if (timeSinceLastFetch.TotalMinutes < 5)
                {
                    weatherApi = weather.Item1;
                }
                else
                {
                    weatherApi = await instance.FetchWeather(latitude, longitude);
                    instance.data[location] = new(weatherApi, DateTime.Now);
                }
            }
            catch
            {
                weatherApi = await instance.FetchWeather(latitude, longitude);
                instance.data.Add(location, new(weatherApi, DateTime.Now));
            }

            return weatherApi;
        }

        private WeatherData() { }
    }
}

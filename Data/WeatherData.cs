using WeatherFlex.Model.Weather;
using WeatherFlex.Services;

namespace WeatherFlex.Data
{
    public class WeatherData
    {
        readonly Dictionary<Tuple<double, double>, WeatherAPI> data = new();

        static WeatherData instance;

        public static async Task<WeatherAPI> GetFor(double latitude, double longitude)
        {
            instance ??= new WeatherData();

            Tuple<double, double> location = new(latitude, longitude);
            if (instance.data.ContainsKey(location))
            {
                return instance.data[location];
            }

            WeatherAPI weatherApi = await new WeatherService().FetchWeather(latitude, longitude);
            weatherApi.LocationProperties = await new GeolocationService().GetLocationPropertiesAsync(latitude, longitude);

            instance.data.Add(location, weatherApi);

            return weatherApi;
        }

        private WeatherData() { }
    }
}

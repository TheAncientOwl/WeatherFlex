using WeatherFlex.Data;
using WeatherFlex.Model.Weather;
using WeatherFlex.Services;

namespace WeatherFlex.ViewModels
{
    public class WeatherViewModel
    {
        static readonly int TEMPERATURES_COUNT_LIMIT = 25;

        public WeatherAPI WeatherAPI { get; private set; }

        public WeatherViewModel() { }

        public async Task GetUserWeatherAsync()
        {
            Location userLocation = await new GeolocationService().GetLocationAsync();

            await GetWeatherAsync(userLocation.Latitude, userLocation.Longitude);
        }

        public async Task GetWeatherAsync(double latitude, double longitude)
        {
            WeatherAPI = await WeatherData.GetFor(latitude, longitude);
        }

        public List<Temperature> GetHourlyTemperature()
        {
            DateTime now = DateTime.Now;

            List<Temperature> temperatures = new();
            TemperatureForecast temperatureForecast = WeatherAPI.TemperatureForecast;

            for (int i = 0, temperaturesCountLimit = TEMPERATURES_COUNT_LIMIT; 
                i < temperatureForecast.Temperature.Count && temperaturesCountLimit > 0; 
                i++)
            {
                DateTime time = temperatureForecast.GetDateTimeAt(i);

                if (time.Day > now.Day || (time.Day == now.Day && time.Hour >= now.Hour))
                {
                    temperaturesCountLimit--;
                    temperatures.Add(new Temperature()
                    {
                        Time = temperatureForecast.Time[i],
                        Value = temperatureForecast.Temperature[i],
                        Units = WeatherAPI.WeatherUnits.Units,
                        PrecipitationProbability = temperatureForecast.PrecipitationProbability[i],
                        WeatherCode = WeatherCode.FromCode(temperatureForecast.Weathercode[i])
                    });
                }
            }

            temperatures[0].IsNow = true;

            return temperatures;
        }
    }
}

using WeatherFlex.Model.Weather;
using WeatherFlex.Services;

namespace WeatherFlex.ViewModels
{
    public class WeatherViewModel
    {
        static readonly int TEMPERATURES_COUNT_LIMIT = 25;

        readonly WeatherService weatherService;
        readonly GeolocationService geolocationService;

        public WeatherAPI WeatherAPI { get; private set; }

        public WeatherViewModel(WeatherService weatherService, GeolocationService geolocationService)
        {
            this.weatherService = weatherService;
            this.geolocationService = geolocationService;
        }

        public async Task GetUserWeatherAsync()
        {
            Location userLocation = await geolocationService.GetLocationAsync();

            await GetWeatherAsync(userLocation.Latitude, userLocation.Longitude);
        }

        public async Task GetWeatherAsync(double latitude, double longitude)
        {
            WeatherAPI = await weatherService.FetchWeather(latitude, longitude);

            WeatherAPI.LocationProperties = await geolocationService.GetLocationPropertiesAsync(latitude, longitude);
        }

        public List<Temperature> GetHourlyTemperature()
        {
            DateTime now = DateTime.Now;

            List<Temperature> temperatures = new();
            HourlyTemperature hourlyTemperature = WeatherAPI.HourlyTemperature;

            for (int i = 0, temperaturesCountLimit = TEMPERATURES_COUNT_LIMIT; 
                i < hourlyTemperature.Temperature.Count && temperaturesCountLimit > 0; 
                i++)
            {
                DateTime time = hourlyTemperature.GetDateTimeAt(i);

                if (time.Day > now.Day || (time.Day == now.Day && time.Hour >= now.Hour))
                {
                    temperaturesCountLimit--;
                    temperatures.Add(new Temperature()
                    {
                        Time = hourlyTemperature.Time[i],
                        Value = hourlyTemperature.Temperature[i],
                        Units = WeatherAPI.HourlyUnits.Units,
                        PrecipitationProbability = hourlyTemperature.PrecipitationProbability[i],
                        WeatherCode = WeatherCode.FromCode(hourlyTemperature.Weathercode[i])
                    });
                }
            }

            temperatures[0].IsNow = true;

            return temperatures;
        }
    }
}

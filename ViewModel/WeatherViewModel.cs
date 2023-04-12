using WeatherFlex.Model;
using WeatherFlex.Services;

namespace WeatherFlex.ViewModels
{
    public class WeatherViewModel
    {
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
            List<Temperature> temperatures = new();
            HourlyTemperature hourlyTemperature = WeatherAPI.HourlyTemperature;

            for (int i = 0; i < hourlyTemperature.Temperature.Count; i++)
            {
                temperatures.Add(new Temperature()
                {
                    Time = hourlyTemperature.Time[i],
                    Value = hourlyTemperature.Temperature[i],
                    Units = WeatherAPI.HourlyUnits.Units,
                    PrecipitationProbability = hourlyTemperature.PrecipitationProbability[i],
                    WeatherInterpretation = Weathercodes.Interpretation[hourlyTemperature.Weathercode[i]]
                }); ;
            }

            return temperatures;
        }
    }
}

using WeatherFlex.Model;
using WeatherFlex.Services;

namespace WeatherFlex.ViewModels
{
    public class WeatherViewModel
    {
        readonly WeatherService weatherService;
        readonly GeolocationService geolocationService;

        public WeatherAPI Weather { get; private set; }

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
            Weather = await weatherService.FetchWeather(latitude, longitude);

            Weather.LocationProperties = await geolocationService.GetLocationPropertiesAsync(latitude, longitude);
        }
    }
}

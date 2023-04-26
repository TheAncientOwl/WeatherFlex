using WeatherFlex.Database;
using WeatherFlex.Model;
using WeatherFlex.View;
using WeatherFlex.ViewModels;

namespace WeatherFlex.ViewModel
{
    public class CarouselViewModel
    {
        public List<CarouselContent> FavLocations { get; set; }

        public async Task LoadFavLocationsAsync(Window window)
        {
            FavLocationsDao favLocationsDao = new();
            List<FavLocation> locations = await favLocationsDao.Get();
            await favLocationsDao.CloseAsync();

            SettingsDao settingsDao = new();
            Settings userSettings = await settingsDao.Get();
            await settingsDao.CloseAsync();

            FavLocations = new();
            foreach (FavLocation location in locations)
            {
                var viewModel = new WeatherViewModel();
                await viewModel.GetWeatherAsync(location.Latitude, location.Longitude);

                FavLocations.Add(new CarouselContent() { LocationContent = new WeatherView(viewModel, window, userSettings) });
            }
        }
    }
}

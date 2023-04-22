using WeatherFlex.Database;
using WeatherFlex.Model;
using WeatherFlex.Services;

namespace WeatherFlex.View;

public partial class FavoritesPage : ContentPage
{
    public FavoritesPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        FavLocationsDao favLocationsDao = new();
        List<FavLocation> favLocations = await favLocationsDao.Get();

        listViewFavorite.ItemsSource = favLocations;

        await favLocationsDao.CloseAsync();
    }

    private async void AddFavorite_Button_Clicked(object sender, EventArgs e)
    {
        var city = entryCity.Text;
        var country = entryCountry.Text;

        LocationData location = await new GeolocationService().GetLocationDataAsync(city, country);

        if (location != null)
        {
            FavLocationsDao favLocationsDao = new();
            await favLocationsDao.Insert(new FavLocation()
            {
                City = city,
                CountryCode = country,
                Latitude = location.Latitude,
                Longitude = location.Longitude
            });
            await favLocationsDao.CloseAsync();
        }
    }
}

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

        listViewFavorite.ItemsSource = await favLocationsDao.Get();

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
                City = Capitalize(city),
                CountryCode = Capitalize(country),
                Latitude = location.Latitude,
                Longitude = location.Longitude
            });

            listViewFavorite.ItemsSource = await favLocationsDao.Get();

            await favLocationsDao.CloseAsync();
        }
    }

    static string Capitalize(string str) => char.ToUpper(str[0]) + str.Substring(1);
}

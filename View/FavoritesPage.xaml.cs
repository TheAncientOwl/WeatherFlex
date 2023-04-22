using WeatherFlex.Database;
using WeatherFlex.Model;

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

    private void Button_Clicked_Favorites(object sender, EventArgs e)
    {

    }
}
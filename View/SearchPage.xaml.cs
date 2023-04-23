using WeatherFlex.Model;
using WeatherFlex.Services;

namespace WeatherFlex.View;

public partial class SearchPage : ContentPage
{
    public SearchPage()
    {
        InitializeComponent();
    }

    private async void OnSearchButtonClicked(object sender, EventArgs e)
    {
        var city = entryCity.Text;
        var country = entryCountry.Text;

        LocationData location = await new GeolocationService().GetLocationDataAsync(city, country);

        if (location != null)
        {
            await Navigation.PushAsync(new WeatherPage("Forecast in " + city + ", " + country + " is :", location.Latitude, location.Longitude, Window));
        }
    }
}

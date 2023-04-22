using System.Collections.ObjectModel;
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

    }


}




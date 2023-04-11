using WeatherFlex.ContentViews;
using WeatherFlex.ViewModels;

namespace WeatherFlex;

public partial class HomePage : ContentPage
{
    WeatherLocationViewModel UserLocation { get; set; }

    public HomePage()
    {
        InitializeComponent();
    }
}

using WeatherFlex.View.Feedback;
using WeatherFlex.View;
using WeatherFlex.ViewModels;
using WeatherFlex.Services;

namespace WeatherFlex;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        Content = new InfoView("Loading location...");

        WeatherViewModel weatherViewModel = new(new WeatherService(), new GeolocationService());
        await weatherViewModel.GetUserWeatherAsync();

        Content = new WeatherView(weatherViewModel);
    }
}

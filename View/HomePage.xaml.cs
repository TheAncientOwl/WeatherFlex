using WeatherFlex.View;
using WeatherFlex.ViewModels;
using WeatherFlex.Services;
using WeatherFlex.View.Feedback;

namespace WeatherFlex;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        Content = new InfoView("Loading data...");

        WeatherViewModel weatherViewModel = new();
        await weatherViewModel.GetUserWeatherAsync();

        Content = new WeatherView(weatherViewModel, Window);
    }
}

using WeatherFlex.View;
using WeatherFlex.Model;
using WeatherFlex.Services;
using WeatherFlex.View.Feedback;
using WeatherFlex.Database;
using WeatherFlex.ViewModels;

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

        WeatherViewModel weatherViewModel = new(new WeatherService(), new GeolocationService());
        await weatherViewModel.GetUserWeatherAsync();

        SettingsDao settingsDao = new();
        Settings userSettings = await settingsDao.Get();
        await settingsDao.CloseAsync();

        Content = new WeatherView(weatherViewModel, Window, userSettings);
    }
}

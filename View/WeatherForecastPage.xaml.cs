using WeatherFlex.Services;
using WeatherFlex.View.Feedback;
using WeatherFlex.ViewModel;

namespace WeatherFlex.View;

public partial class WeatherForecastPage : ContentPage
{
    
    public WeatherForecastPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        var contentBackup = Content;
        Content = new InfoView("Loading data...");

        var viewModel = new WeatherForecastViewModel();

        var userLocation = await new GeolocationService().GetLocationAsync();

        await viewModel.FetchWeatherForecast(userLocation.Latitude, userLocation.Longitude);

        Content = contentBackup;
        BindingContext = viewModel;

        hourlyWeatherForecast.ItemsSource = viewModel.GetForecastValues();
    }
}

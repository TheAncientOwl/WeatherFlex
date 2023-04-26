using WeatherFlex.Database;
using WeatherFlex.Model;
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

        SettingsDao settingsDao = new();
        Settings userSettings = await settingsDao.Get();
        await settingsDao.CloseAsync();

        hourlyWeatherForecast.ItemsSource = viewModel.GetForecastValues(userSettings);
        hourlyWeatherScrollView.MaximumWidthRequest = ForecastViewWidth;
        Window.SizeChanged += WindowSizeChanged;
    }

    void WindowSizeChanged(object sender, EventArgs e) =>
        hourlyWeatherScrollView.MaximumWidthRequest = ForecastViewWidth;

    double ForecastViewWidth { get => Window.Width - Window.Width * 0.05; }
}

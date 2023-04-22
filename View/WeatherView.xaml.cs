using WeatherFlex.Model;
using WeatherFlex.Model.Weather;
using WeatherFlex.ViewModels;

namespace WeatherFlex.View;

public partial class WeatherView : ContentView
{
    readonly Window window;

    public WeatherView(WeatherViewModel viewModel, Window window, Settings userSettings)
    {
        InitializeComponent();

        this.window = window;

        WeatherAPI weatherApi = viewModel.WeatherAPI;
        if (!userSettings.PreffersCelsius)
        {
            weatherApi.WeatherUnits.Units = "°F";
            weatherApi.CurrentWeather.Temperature = WeatherViewModel.ToFahrenheit(weatherApi.CurrentWeather.Temperature);
        }

        BindingContext = weatherApi;

        hourlyWeather.ItemsSource = viewModel.GetHourlyTemperature(userSettings);

        hourlyWeatherScrollView.MaximumWidthRequest = ForecastViewWidth;

        window.SizeChanged += WindowSizeChanged;
    }

    void WindowSizeChanged(object sender, EventArgs e)
    {
        hourlyWeatherScrollView.MaximumWidthRequest = ForecastViewWidth;
    }

    double ForecastViewWidth { get => window.Width - window.Width * 0.05; }
}

using WeatherFlex.Model;
using WeatherFlex.Model.Weather;
using WeatherFlex.ViewModels;

namespace WeatherFlex.View;

public partial class WeatherView : ContentView
{
    readonly Window window;

    static WeatherAPI FahrenheitSemiShallowClone(WeatherAPI weatherApi)
    {
        WeatherAPI clone = new()
        {
            LocationProperties = weatherApi.LocationProperties,
            Timezone = weatherApi.Timezone,
            TemperatureForecast = weatherApi.TemperatureForecast,
            WeatherUnits = new WeatherUnits()
            {
                Time = weatherApi.WeatherUnits.Time,
                Units = "°F"
            },
            CurrentWeather = new Weather()
            {
                WindSpeed = weatherApi.CurrentWeather.WindSpeed,
                Time = weatherApi.CurrentWeather.Time,
                Weathercode = weatherApi.CurrentWeather.Weathercode,
                WeatherInterpretation = weatherApi.CurrentWeather.WeatherInterpretation,
                Temperature = WeatherViewModel.ToFahrenheit(weatherApi.CurrentWeather.Temperature)
            }
        };

        return clone;
    }

    public WeatherView(WeatherViewModel viewModel, Window window, Settings userSettings)
    {
        InitializeComponent();

        this.window = window;
        window.SizeChanged += WindowSizeChanged;

        BindingContext =
            userSettings.PreffersCelsius
            ? viewModel.WeatherAPI
            : FahrenheitSemiShallowClone(viewModel.WeatherAPI);

        hourlyWeather.ItemsSource = viewModel.GetHourlyTemperature(userSettings);
        hourlyWeatherScrollView.MaximumWidthRequest = ForecastViewWidth;
    }

    void WindowSizeChanged(object sender, EventArgs e) =>
        hourlyWeatherScrollView.MaximumWidthRequest = ForecastViewWidth;

    double ForecastViewWidth { get => window.Width - window.Width * 0.05; }
}
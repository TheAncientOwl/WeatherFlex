using WeatherFlex.ViewModels;

namespace WeatherFlex.View;

public partial class WeatherView : ContentView
{
	private static readonly int HOURLY_WEATHER_WIDTH_DECREASE = 55;
	readonly Window window;

	public WeatherView(WeatherViewModel viewModel, Window window)
	{
		InitializeComponent();

		this.window = window;

		BindingContext = viewModel.WeatherAPI;

		hourlyWeather.ItemsSource = viewModel.GetHourlyTemperature();

		hourlyWeatherScrollView.MaximumWidthRequest = window.Width - HOURLY_WEATHER_WIDTH_DECREASE;
		
		window.SizeChanged += WindowSizeChanged;
	}

    private void WindowSizeChanged(object sender, EventArgs e)
	{
		hourlyWeatherScrollView.MaximumWidthRequest = window.Width - HOURLY_WEATHER_WIDTH_DECREASE;
	}
}

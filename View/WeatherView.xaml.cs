using WeatherFlex.Model;
using WeatherFlex.ViewModels;

namespace WeatherFlex.View;

public partial class WeatherView : ContentView
{
	readonly Window window;

	public WeatherView(WeatherViewModel viewModel, Window window, Settings userSettings)
	{
		InitializeComponent();

		this.window = window;

		BindingContext = viewModel.WeatherAPI;

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

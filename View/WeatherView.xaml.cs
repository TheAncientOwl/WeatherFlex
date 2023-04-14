using WeatherFlex.ViewModels;

namespace WeatherFlex.View;

public partial class WeatherView : ContentView
{
	readonly Window window;

	public WeatherView(WeatherViewModel viewModel, Window window)
	{
		InitializeComponent();

		this.window = window;

		BindingContext = viewModel.WeatherAPI;

		hourlyWeather.ItemsSource = viewModel.GetHourlyTemperature();

		hourlyWeatherScrollView.MaximumWidthRequest = ForecastViewWidth;
		
		window.SizeChanged += WindowSizeChanged;
	}

    void WindowSizeChanged(object sender, EventArgs e)
	{
		hourlyWeatherScrollView.MaximumWidthRequest = ForecastViewWidth;
	}

	double ForecastViewWidth { get => window.Width - window.Width * 0.04; }
}

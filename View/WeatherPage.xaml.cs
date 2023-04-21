using WeatherFlex.View.Feedback;
using WeatherFlex.ViewModels;

namespace WeatherFlex.View;

public partial class WeatherPage : ContentPage
{
	readonly double latitude;
	readonly double longitude;

	public WeatherPage(string title, double latitude, double longitude)
	{
		InitializeComponent();

		this.latitude = latitude;
		this.longitude = longitude;

		Title = title;
	}

    protected override async void OnAppearing()
    {
		Content = new InfoView("Loading data...");

		WeatherViewModel weatherViewModel = new();
		await weatherViewModel.GetWeatherAsync(latitude, longitude);

		Content = new WeatherView(weatherViewModel, Window);
    }
}

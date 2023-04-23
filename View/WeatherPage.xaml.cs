using WeatherFlex.Database;
using WeatherFlex.View.Feedback;
using WeatherFlex.ViewModels;

namespace WeatherFlex.View;

public partial class WeatherPage : ContentPage
{
	readonly double latitude;
	readonly double longitude;
	readonly Window window;

	public WeatherPage(string title, double latitude, double longitude, Window window) 
		: this(title, latitude, longitude)
	{
		this.window = window;
	}

	public WeatherPage(string title, double latitude, double longitude)
	{
		InitializeComponent();

		this.latitude = latitude;
		this.longitude = longitude;

		Title = title;

		window = Window;
	}

    protected override async void OnAppearing()
    {
		Content = new InfoView("Loading data...");

		WeatherViewModel weatherViewModel = new();
		await weatherViewModel.GetWeatherAsync(latitude, longitude);

		SettingsDao settingsDao = new();
		var userSettings = await settingsDao.Get();
		await settingsDao.CloseAsync();
    }
}

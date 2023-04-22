namespace WeatherFlex.View;

using WeatherFlex.ViewModel;

public partial class SettingsPage : ContentPage
{
    readonly SettingsViewModel viewModel;

	public SettingsPage()
	{
		InitializeComponent();

        viewModel = new SettingsViewModel();
	}

    protected override async void OnAppearing()
    {
        await viewModel.LoadSettingsAsync();

        BindingContext = viewModel;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FavoritesPage());
    }

    private async void Celsius_TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await viewModel.TogglePreffersCelsius();
    }

    private async void Fahrenheit_TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await viewModel.TogglePreffersFahrenheit();
    }
}

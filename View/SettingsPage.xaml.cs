namespace WeatherFlex.View;
using WeatherFlex.Database;
public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();

	}

    protected override async void OnAppearing()
    {
        var settings = new SettingsDao();

        BindingContext = await settings.Get();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FavoritesPage());
    }
}
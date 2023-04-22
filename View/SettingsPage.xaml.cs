namespace WeatherFlex.View;
using WeatherFlex.ViewModel;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        var viewModel = new SettingsViewModel();
        await viewModel.LoadSettingsAsync();

        BindingContext = viewModel;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FavoritesPage());
    }
}
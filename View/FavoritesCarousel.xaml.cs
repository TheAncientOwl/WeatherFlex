using WeatherFlex.ViewModel;

namespace WeatherFlex.View;

public partial class FavoritesCarousel : ContentPage
{
	public FavoritesCarousel()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
		CarouselViewModel viewModel = new();
		await viewModel.LoadFavLocationsAsync(Window);

		BindingContext = viewModel;
    }
}

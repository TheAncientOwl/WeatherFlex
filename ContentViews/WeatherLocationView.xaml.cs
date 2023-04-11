using WeatherFlex.ViewModels;

namespace WeatherFlex.ContentViews;

public partial class WeatherLocationView : ContentView
{
	public WeatherLocationView(WeatherLocationViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}

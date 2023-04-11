using WeatherFlex.ViewModels;

namespace WeatherFlex.View;

public partial class WeatherView : ContentView
{
	public WeatherView(WeatherViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel.WeatherAPI;
	}
}

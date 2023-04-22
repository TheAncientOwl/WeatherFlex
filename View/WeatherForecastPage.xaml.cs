using WeatherFlex.ViewModel;

namespace WeatherFlex.View;

public partial class WeatherForecastPage : ContentPage
{
    
    public WeatherForecastPage()
    {
        InitializeComponent();
        this.BindingContext = new WeatherForecastModel();

    }
}
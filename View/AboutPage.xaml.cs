using System.Windows.Input;

namespace WeatherFlex.View;

public partial class AboutPage : ContentPage
{
    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public AboutPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
}

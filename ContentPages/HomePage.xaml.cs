using WeatherFlex.ContentViews;
using WeatherFlex.ViewModels;

namespace WeatherFlex;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        Content = new InfoView("Loading location...");

        try
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync() ??
                                await Geolocation.Default.GetLocationAsync(new GeolocationRequest()
                                {
                                    DesiredAccuracy = GeolocationAccuracy.Medium,
                                    Timeout = TimeSpan.FromSeconds(30)
                                });

            if (location != null)
            {
                var userLocationWeatherViewModel = new WeatherLocationViewModel() { Latitude = location.Latitude, Longitude = location.Longitude };

                Content = new WeatherLocationView(userLocationWeatherViewModel);
            }
            else
            {
                Content = new ErrorView("Unable to get your last location to display the weather.");
            }
        }
        catch (FeatureNotSupportedException)
        {
            Content = new ErrorView("Geolocation not supported on this device.");
        }
        catch (FeatureNotEnabledException)
        {
            Content = new ErrorView("Geolocation not enabled on this device.");
        }
        catch (PermissionException)
        {
            Content = new ErrorView("The app does not have permission to use geolocation on this device.");
        }
        catch (Exception e)
        {
            Content = new ErrorView("Unable to get your location to display the weather. Make sure the application has location access.\n" + e.Message);
        }
    }
}

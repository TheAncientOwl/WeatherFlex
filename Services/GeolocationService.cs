namespace WeatherFlex.Services
{
    public class GeolocationService
    {
        readonly IGeolocation geolocation;

        public GeolocationService()
        {
            geolocation = Geolocation.Default;
        }

        public async Task<Location> GetLocationAsync()
        {
            Location location = null;
            string errorMessage = null;

            try
            {
                location = await geolocation.GetLastKnownLocationAsync() ??
                           await geolocation.GetLocationAsync(new GeolocationRequest()
                           {
                               DesiredAccuracy = GeolocationAccuracy.Medium,
                               Timeout = TimeSpan.FromSeconds(30)
                           });

                if (location == null)
                {
                    errorMessage = "Unable to get your last location to display the weather.";
                }
            }
            catch (FeatureNotSupportedException)
            {
                errorMessage = "Geolocation not supported on this device.";
            }
            catch (FeatureNotEnabledException)
            {
                errorMessage = "Geolocation not enabled on this device.";
            }
            catch (PermissionException)
            {
                errorMessage = "The app does not have permission to use geolocation on this device.";
            }
            catch (Exception e)
            {
                errorMessage = "Unable to get your location to display the weather. Make sure the application has location access.\n" + e.Message;
            }

            if (errorMessage != null)
            {
                await Shell.Current.DisplayAlert("Error", errorMessage, "OK");
                location = new Location(0, 0);
            }

            return location;
        }
    }
}

using System.Globalization;
using System.Net.Http.Json;
using WeatherFlex.Model;

namespace WeatherFlex.Services
{
    public class GeolocationService
    {
        static readonly string GEOLOCATION_API_LINK = "https://api.geoapify.com/v1/geocode/reverse?lat={0}&lon={1}&apiKey=440a320e3a31460eb65e2b2d5bbb53dd";
        readonly IGeolocation geolocation;
        readonly HttpClient httpClient;

        public GeolocationService()
        {
            geolocation = Geolocation.Default;
            httpClient = new HttpClient();
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

        public async Task<LocationProperties> GetLocationPropertiesAsync(double latitude, double longitude)
        {
            var link = string.Format(GEOLOCATION_API_LINK, ((float)latitude).ToString(CultureInfo.GetCultureInfo("en-US")), ((float)longitude).ToString(CultureInfo.GetCultureInfo("en-US")));

            LocationFeatures locationFeatures = await httpClient.GetFromJsonAsync<LocationFeatures>(link);


            return locationFeatures.Features[0].LocationProperties;
        }
    }
}

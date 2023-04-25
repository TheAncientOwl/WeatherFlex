using System.Globalization;
using System.Net.Http.Json;
using WeatherFlex.Model;

namespace WeatherFlex.Services
{
    public class GeolocationService
    {
        static readonly string REVERSE_GEOLOCATION_API_LINK = "https://api.geoapify.com/v1/geocode/reverse?lat={0}&lon={1}&apiKey=440a320e3a31460eb65e2b2d5bbb53dd";
        static readonly string GEOLOCATION_API_LINK = "https://api.geoapify.com/v1/geocode/search?text={0}&filter=countrycode:{1}&apiKey=440a320e3a31460eb65e2b2d5bbb53dd"; // 0 - city, 1 country code

        readonly IGeolocation geolocation = Geolocation.Default;
        readonly HttpClient httpClient = new();

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
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-US");

            var link = string.Format(
                REVERSE_GEOLOCATION_API_LINK,
                ((float)latitude).ToString(cultureInfo),
                ((float)longitude).ToString(cultureInfo));

            try
            {
                LocationFeatures locationFeatures = await httpClient.GetFromJsonAsync<LocationFeatures>(link);

                return locationFeatures.Features[0].LocationProperties;
            }
            catch
            {
                await Shell.Current.DisplayAlert("Internet error", "Checkk your internet connection", "OK");
                return null;
            }
        }

        public async Task<LocationData> GetLocationDataAsync(string city, string countryCode)
        {
            if (city == null || countryCode == null || city.Length == 0 || countryCode.Length == 0)
                return null;

            var link = string.Format(
                GEOLOCATION_API_LINK,
                city.ToLower(),
                countryCode.ToLower());
            try
            {
                LocationDataWrapper locationWrapper = await httpClient.GetFromJsonAsync<LocationDataWrapper>(link);

                if (locationWrapper.Features.Count == 0)
                {
                    await Shell.Current.DisplayAlert("Unknown Location", "Provided location is not valid", "OK");
                    return null;
                }

                return locationWrapper.Features[0].LocationData;
            }
            catch
            {
                await Shell.Current.DisplayAlert("Unknown Location", "Provided location is not valid", "OK");

                return new LocationData() { Latitude = 100000, Longitude = 100000 };
            }
        }
    }
}

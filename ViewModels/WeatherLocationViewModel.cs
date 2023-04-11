using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeatherFlex.ViewModels
{
    public class WeatherLocationViewModel : INotifyPropertyChanged
    {
        private double latitude;
        private double longitude;

        public double Latitude
        {
            get => latitude;
            set
            {
                if (latitude != value)
                {
                    latitude = value;
                    OnPropertyChanged(nameof(Latitude));
                }
            }
        }

        public double Longitude
        {
            get => longitude;
            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    OnPropertyChanged(nameof(Longitude));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

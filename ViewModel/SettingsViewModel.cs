using WeatherFlex.Database;
using WeatherFlex.Model;
using System.Windows.Input;

namespace WeatherFlex.ViewModel
{
    public class SettingsViewModel
    {
        Settings userSettings;

        public bool PreffersCelsius { get => userSettings.PreffersCelsius; }

        public bool PreffersFahrenheit { get => !userSettings.PreffersCelsius; set { } }

        //public ICommand ToggleCelsius { get; set; }

        //public Command ToggleFahrenheit { get; set; }

        //public SettingsViewModel()
        //{
        //    ToggleCelsius = TogglePreffersCelsius;
        //    ToggleFahrenheit = TogglePreffersFahrenheit;
        //}

        public async void TogglePreffersCelsius(object sender, TappedEventArgs args)
        {
            if (userSettings.PreffersCelsius)
            {
                SettingsDao dao = new();
                
                userSettings.PreffersCelsius = false;
                await dao.Update(userSettings);

                await dao.CloseAsync();
            }
        }

        public async void TogglePreffersFahrenheit(object sender, TappedEventArgs args)
        {
            if (!userSettings.PreffersCelsius)
            {
                SettingsDao dao = new();

                userSettings.PreffersCelsius = true;
                await dao.Update(userSettings);

                await dao.CloseAsync();
            }
        }

        public async Task LoadSettingsAsync()
        {
            SettingsDao dao = new();

            userSettings = await dao.Get();

            await dao.CloseAsync();
        }
    }
}

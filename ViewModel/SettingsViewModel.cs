using WeatherFlex.Database;
using WeatherFlex.Model;

namespace WeatherFlex.ViewModel
{
    public class SettingsViewModel
    {
        Settings userSettings;

        public bool PreffersCelsius { get => userSettings.PreffersCelsius; }

        public bool PreffersFahrenheit { get => !userSettings.PreffersCelsius; set { } }

        public Command ToggleCelsius { get; set; }

        public Command ToggleFahrenheit { get; set; }

        public SettingsViewModel()
        {
            ToggleCelsius = new Command(TogglePreffersCelsius);
            ToggleFahrenheit = new Command(TogglePreffersFahrenheit);
        }

        async void TogglePreffersCelsius()
        {
            if (userSettings.PreffersCelsius)
            {
                SettingsDao dao = new();
                
                userSettings.PreffersCelsius = false;
                await dao.Update(userSettings);

                await dao.CloseAsync();
            }
        }

        async void TogglePreffersFahrenheit()
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

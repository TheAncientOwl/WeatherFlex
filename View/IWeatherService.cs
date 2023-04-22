namespace WeatherFlex.View
{
    internal interface IWeatherService
    {
        Task GetWeatherForecastsAsync(string location);
    }
}
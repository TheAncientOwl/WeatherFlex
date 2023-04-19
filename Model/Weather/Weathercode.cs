namespace WeatherFlex.Model.Weather
{
    public class WeatherCode
    {
        public string Interpretation { get; private set; }
        public Color BackgroundColor { get; private set; }
        public Color TextColor { get; private set; }

        private WeatherCode(string interpretation, Color backgroundColor, Color textColor)
        {
            Interpretation = interpretation;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
        }

        public static WeatherCode FromCode(int code)
        {
            try
            {
                return Dictionary[code];
            }
            catch
            {
                return new WeatherCode("Unknown", Colors.LightSkyBlue, Colors.DimGray);
            }
        }

        private static readonly Dictionary<int, WeatherCode> Dictionary = new(28)
        {
            { 0,  new WeatherCode("Clear sky", Color.FromRgb(135, 206, 235), Color.FromRgb(255, 255, 255)) },
            { 1,  new WeatherCode("Mainly clear", Color.FromRgb(135, 206, 235), Color.FromRgb(0, 0, 0)) },
            { 2,  new WeatherCode("Partly cloudy", Color.FromRgb(176, 224, 230), Color.FromRgb(0, 0, 0)) },
            { 3,  new WeatherCode("Overcast", Color.FromRgb(119, 136, 153), Color.FromRgb(255, 255, 255)) },
            { 45, new WeatherCode("Fog", Color.FromRgb(211, 211, 211), Color.FromRgb(0, 0, 0)) },
            { 48, new WeatherCode("Rime fog", Color.FromRgb(240, 255, 255), Color.FromRgb(0, 0, 0)) },
            { 51, new WeatherCode("Light drizzle", Color.FromRgb(192, 192, 192), Color.FromRgb(0, 0, 0)) },
            { 53, new WeatherCode("Moderate drizzle", Color.FromRgb(192, 192, 192), Color.FromRgb(0, 0, 0)) },
            { 55, new WeatherCode("Dense drizzle", Color.FromRgb(192, 192, 192), Color.FromRgb(255, 255, 255)) },
            { 56, new WeatherCode("Light freezing drizzle", Color.FromRgb(240, 248, 255), Color.FromRgb(0, 0, 0)) },
            { 57, new WeatherCode("Dense freezing drizzle", Color.FromRgb(240, 248, 255), Color.FromRgb(0, 0, 0)) },
            { 61, new WeatherCode("Slight rain", Color.FromRgb(173, 216, 230), Color.FromRgb(0, 0, 0)) },
            { 63, new WeatherCode("Moderate rain", Color.FromRgb(70, 130, 180), Color.FromRgb(255, 255, 255)) },
            { 65, new WeatherCode("Heavy rain", Color.FromRgb(30, 144, 255), Color.FromRgb(255, 255, 255)) },
            { 66, new WeatherCode("Light freezing rain", Color.FromRgb(240, 248, 255), Color.FromRgb(0, 0, 0)) },
            { 67, new WeatherCode("Heavy freezing rain", Color.FromRgb(240, 248, 255), Color.FromRgb(0, 0, 0)) },
            { 71, new WeatherCode("Slight snow fall", Color.FromRgb(245, 245, 245), Color.FromRgb(0, 0, 0)) },
            { 73, new WeatherCode("Moderate snow fall", Color.FromRgb(211, 211, 211), Color.FromRgb(0, 0, 0)) },
            { 75, new WeatherCode("Heavy snow fall", Color.FromRgb(119, 136, 153), Color.FromRgb(255, 255, 255)) },
            { 77, new WeatherCode("Snow grains", Color.FromRgb(245, 245, 245), Color.FromRgb(0, 0, 0)) },
            { 80, new WeatherCode("Slight rain showers", Color.FromRgb(135, 206, 250), Color.FromRgb(0, 0, 0)) },
            { 81, new WeatherCode("Moderate rain showers", Color.FromRgb(70, 130, 180), Color.FromRgb(255, 255, 255)) },
            { 82, new WeatherCode("Heavy rain showers", Color.FromRgb(30, 144, 255), Color.FromRgb(255, 255, 255)) },
            { 85, new WeatherCode("Slight snow showers", Color.FromRgb(245, 245, 245), Color.FromRgb(0, 0, 0)) },
            { 86, new WeatherCode("Heavy snow showers", Color.FromRgb(211, 211, 211), Color.FromRgb(255, 255, 255)) },
            { 95, new WeatherCode("Thunderstorm", Color.FromRgb(128, 128, 128), Color.FromRgb(255, 255, 255)) },
            { 96, new WeatherCode("Thunderstorm with slight hail", Color.FromRgb(128, 128, 128), Color.FromRgb(255, 255, 255)) },
            { 99, new WeatherCode("Thunderstorm with heavy hail", Color.FromRgb(128, 128, 128), Color.FromRgb(255, 255, 255)) }
        };
    }
}

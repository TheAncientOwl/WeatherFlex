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
            { 0,  new WeatherCode("Clear sky", Colors.LightSkyBlue, Colors.DimGray) },
            { 1,  new WeatherCode("Mainly clear", Colors.LightSkyBlue, Colors.DimGray) },
            { 2,  new WeatherCode("Partly cloudy", Colors.LightSkyBlue, Colors.DimGray) },
            { 3,  new WeatherCode("Overcast", Colors.LightSkyBlue, Colors.DimGray) },
            { 45, new WeatherCode("Fog", Colors.LightSkyBlue, Colors.DimGray) },
            { 48, new WeatherCode("Rime fog", Colors.LightSkyBlue, Colors.DimGray) },
            { 51, new WeatherCode("Light drizzle", Colors.LightSkyBlue, Colors.DimGray) },
            { 53, new WeatherCode("Moderate drizzle", Colors.LightSkyBlue, Colors.DimGray) },
            { 55, new WeatherCode("Dense drizzle", Colors.LightSkyBlue, Colors.DimGray) },
            { 56, new WeatherCode("Light freezing drizzle", Colors.LightSkyBlue, Colors.DimGray) },
            { 57, new WeatherCode("Dense freezing drizzle", Colors.LightSkyBlue, Colors.DimGray) },
            { 61, new WeatherCode("Slight rain", Colors.LightSkyBlue, Colors.DimGray) },
            { 63, new WeatherCode("Moderate rain", Colors.LightSkyBlue, Colors.DimGray) },
            { 65, new WeatherCode("Heavy rain", Colors.LightSkyBlue, Colors.DimGray) },
            { 66, new WeatherCode("Light freezing rain", Colors.LightSkyBlue, Colors.DimGray) },
            { 67, new WeatherCode("Heavy freezing rain", Colors.LightSkyBlue, Colors.DimGray) },
            { 71, new WeatherCode("Slight snow fall", Colors.LightSkyBlue, Colors.DimGray) },
            { 73, new WeatherCode("Moderate snow fall", Colors.LightSkyBlue, Colors.DimGray) },
            { 75, new WeatherCode("Heavy snow fall", Colors.LightSkyBlue, Colors.DimGray) },
            { 77, new WeatherCode("Snow grains", Colors.LightSkyBlue, Colors.DimGray) },
            { 80, new WeatherCode("Slight rain showers", Colors.LightSkyBlue, Colors.DimGray) },
            { 81, new WeatherCode("Moderate rain showers", Colors.LightSkyBlue, Colors.DimGray) },
            { 82, new WeatherCode("Heavy rain showers", Colors.LightSkyBlue, Colors.DimGray) },
            { 85, new WeatherCode("Slight snow showers", Colors.LightSkyBlue, Colors.DimGray) },
            { 86, new WeatherCode("Heavy snow showers", Colors.LightSkyBlue, Colors.DimGray) },
            { 95, new WeatherCode("Thunderstorm", Colors.LightSkyBlue, Colors.DimGray) },
            { 96, new WeatherCode("Thunderstorm with slight hail", Colors.LightSkyBlue, Colors.DimGray) },
            { 99, new WeatherCode("Thunderstorm with heavy hail", Colors.LightSkyBlue, Colors.DimGray) }
        };
    }
}

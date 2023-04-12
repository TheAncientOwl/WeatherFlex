namespace WeatherFlex.Model.Weather
{
    public class Temperature
    {
        public string Time { get; set; }
        public double Value { get; set; }
        public string Units { get; set; }
        public int PrecipitationProbability { get; set; }
        public Weathercode Weathercode { get; set; }
        public string Hour { get => Time.Split('T')[1]; }
    }
}

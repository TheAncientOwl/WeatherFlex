namespace WeatherFlex.Model.Weather
{
    public class Temperature
    {
        public string Time { get; set; }
        public double Value { get; set; }
        public string Units { get; set; }
        public bool IsNow { get; set; } = false;
        public int PrecipitationProbability { get; set; }
        public Weathercode Weathercode { get; set; }
        //public string Hour { get => IsNow ? "Now" : Time.Split('T')[1]; }
        public string Hour { get => Time; }
    }
}

using SQLite;

namespace WeatherFlex.Model
{
    [Table("settings")]
    public class Settings
    {
        [Column("id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        [Column("preffers_celsius")]
        public bool PreffersCelsius { get; set; }

        [Column("fetch_new_weather_delay")]
        public int WeatherDelay { get; set; }
    }
}

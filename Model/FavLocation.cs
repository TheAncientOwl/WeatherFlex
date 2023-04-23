using SQLite;
using WeatherFlex.Database;

namespace WeatherFlex.Model
{
    [Table("fav_locations")]
    public class FavLocation
    {
        [Column("id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("country_code")]
        public string CountryCode { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }

        public string FlagUrl { get => "https://flagcdn.com/40x30/" + CountryCode.ToLower() + ".png"; }

        public Command DeleteAsync { get => new(Delete); }

        async void Delete()
        {
            FavLocationsDao favLocationsDao = new();
            await favLocationsDao.Delete(this);

            await favLocationsDao.CloseAsync();
        }
    }
}

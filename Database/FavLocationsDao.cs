using SQLite;
using WeatherFlex.Model;

namespace WeatherFlex.Database
{
    public class FavLocationsDao
    {
        static readonly List<FavLocation> DEFAULT_LOCATIONS = new() { new FavLocation() { City = "Bucharest", CountryCode = "ro", Latitude = 44.4268, Longitude = 26.1025 } };

        SQLiteAsyncConnection connection;

        public static Action<List<FavLocation>> OnLocationsUpdated { get; set; }

        public async Task InitDatabase()
        {
            if (connection == null)
            {
                string connString = Path.Combine(FileSystem.AppDataDirectory, "weather_flex.db");

                connection = new SQLiteAsyncConnection(connString);

                await connection.CreateTableAsync<FavLocation>();
            }
        }

        public async Task<int> Insert(FavLocation favLocation)
        {
            await InitDatabase();

            var locations = await Get();
            foreach (var location in locations)
            {
                if (location.City == favLocation.City && location.CountryCode == favLocation.CountryCode)
                {
                    await Shell.Current.DisplayAlert("Location already added", "Selected location already exists in favorites", "OK");

                    return -1;
                }
            }

            int result = await connection.InsertAsync(favLocation);

            await HandleLocationsUpdate();

            return result;
        }

        public async Task<List<FavLocation>> Get()
        {
            await InitDatabase();

            var list = await connection.QueryAsync<FavLocation>("SELECT * FROM fav_locations");

            if (list.Count == 0)
            {
                await Insert(DEFAULT_LOCATIONS[0]);

                return DEFAULT_LOCATIONS;
            }
            else
            {
                return list;
            }
        }

        public async Task<int> Delete(FavLocation favLocation)
        {
            await InitDatabase();

            int result = await connection.ExecuteAsync("DELETE FROM fav_locations WHERE id = " + favLocation.Id);

            await HandleLocationsUpdate();

            return result;
        }

        public async Task<int> Update(FavLocation favLocation)
        {
            await InitDatabase();

            await Delete(favLocation);

            int result = await Insert(favLocation);

            await HandleLocationsUpdate();

            return result;
        }

        public async Task CloseAsync()
        {
            await connection.CloseAsync();
        }

        async Task HandleLocationsUpdate()
        {
            if (OnLocationsUpdated != null)
            {
                List<FavLocation> newLocations = await Get();

                OnLocationsUpdated(newLocations);
            }
        }
    }
}

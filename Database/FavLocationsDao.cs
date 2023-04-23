using SQLite;
using WeatherFlex.Model;

namespace WeatherFlex.Database
{
    public class FavLocationsDao
    {
        static readonly List<FavLocation> DEFAULT_LOCATIONS = new() { new FavLocation() { City = "Bucharest", CountryCode = "ro", Latitude = 44.4268, Longitude = 26.1025 } };

        SQLiteAsyncConnection connection;

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

            return await connection.InsertAsync(favLocation);
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

            return await connection.ExecuteAsync("DELETE FROM fav_locations WHERE id = " + favLocation.Id);
        }

        public async Task<int> Update(FavLocation favLocation)
        {
            await InitDatabase();

            await Delete(favLocation);

            return await Insert(favLocation);
        }

        public async Task CloseAsync()
        {
            await connection.CloseAsync();
        }
    }
}

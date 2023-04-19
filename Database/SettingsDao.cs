using SQLite;
using WeatherFlex.Model;

namespace WeatherFlex.Database
{
    public class SettingsDao
    {
        SQLiteAsyncConnection connection;

        public async Task InitDatabase()
        {
            if (connection == null)
            {
                string connString = Path.Combine(FileSystem.AppDataDirectory, "weather_flex.db");

                connection = new SQLiteAsyncConnection(connString);

                await connection.CreateTableAsync<Settings>();
            }
        }

        public async Task<int> Insert(Settings settings)
        {
            await InitDatabase();

            return await connection.InsertAsync(settings);
        }

        public async Task<Settings> Get()
        {
            await InitDatabase();

            List<Settings> list = await connection.QueryAsync<Settings>("SELECT * FROM settings");

            return list[0];
        }

        public async Task<int> Update(Settings settings)
        {
            await InitDatabase();

            await connection.ExecuteAsync("DELETE FROM settings WHERE 1 = 1");

            return await Insert(settings);
        }
    }
}

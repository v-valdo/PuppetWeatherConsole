using Newtonsoft.Json;
using System.Data.SQLite;

namespace PuppetWeatherConsole;

// This class parses and inserts city names and IDs from
// --> bulk.openweathermap.org/sample/daily_14.json.gz
// into an SQLite Database
internal class ParseCities
{
    public class City
    {
        public int id { get; set; }
        public string? name { get; set; }
    }
    public class CityWrapper
    {
        public City? city { get; set; } = new();
    }
    public static void ImportCities()
    {
        // Enter Filepath to .JSON fil here
        string filePath = "jsonfile.json";
        string[] lines = File.ReadAllLines(filePath);

        // Enter SQLite path
        string connString = "Data Source=cities.db;";
        SQLiteConnection conn = new(connString);
        string insertCmd = "insert into cities(id,name) values ($1, $2)";
        conn.Open();

        foreach (string line in lines)
        {
            var WrappedCity = JsonConvert.DeserializeObject<CityWrapper>(line);

            int cityId = WrappedCity.city.id;
            string cityName = WrappedCity.city.name ?? "Error";

            Console.WriteLine(cityId);
            Console.WriteLine(cityName);

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = insertCmd;
                cmd.Parameters.AddWithValue("$1", cityId);
                cmd.Parameters.AddWithValue("$2", cityName);

                cmd.ExecuteNonQuery();
            }
        }
        conn.Close();
    }
}

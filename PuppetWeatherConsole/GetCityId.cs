using System.Data.SQLite;

namespace PuppetWeatherConsole;
public class GetCityId(SQLiteConnection connection)
{
    public string GetCityName()
    {
        Console.WriteLine("Enter the name of your city");
        string city = Console.ReadLine() ?? "Invalid";
        return city.ToLower();
    }
    public int GetCityIdByName(string city)
    {
        int cityId = 0;
        using (var cmd = connection.CreateCommand())
        {
            connection.Open();
            cmd.CommandText = "select id from cities where lower(name) = $1";
            cmd.Parameters.AddWithValue("$1", city.Trim());

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cityId = reader.GetInt32(0);
            }

            connection.Close();

            return cityId;
        }
    }
}

using PuppetWeatherConsole;
using PuppetWeatherConsole.ASCII;
using System.Data.SQLite;
using System.Text.Json;
Console.Title = "PuppetWeatherConsole v.05";
Console.WriteLine("*** PuppetWeatherConsole v.0.5 by vvaldo ***");
Console.WriteLine("*** Supports 22 635 cities ***");
Console.WriteLine();
Console.WriteLine();

while (true)
{
    await Main();
}

async Task Main()
{
    HttpClient client = new();
    Uri baseUri = new Uri("https://api.openweathermap.org/data/2.5/weather?");

    string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cities.db");
    string connString = $"Data Source={dbFilePath};";

    SQLiteConnection conn = new(connString);

    GetCityId gci = new(conn);
    int cityId;
    do
    {
        string cityName = gci.GetCityName();
        cityId = gci.GetCityIdByName(cityName);

        if (cityId == 0)
        {
            Console.WriteLine(cityName + " not found! Try again...");
        }

    } while (cityId == 0);

    //Insert your API Key from OpenWeatherMap here
    string apid = "yourapikey";
    string weatherUri = $"{baseUri}id={cityId}&units=metric&appid={apid}";


    // send GET request to API & print to console
    try
    {
        var response = await client.GetAsync(weatherUri);
        var body = response.Content;
        var weatherData = await body.ReadAsStringAsync();

        var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(weatherData);
        Console.Clear();
        Console.WriteLine($"City: {weatherResponse?.name}");
        Console.WriteLine($"Temperature: {weatherResponse?.main?.temp ?? 0}C");
        Console.WriteLine($"Feels Like: {weatherResponse?.main?.feels_like ?? 0}C");
        Console.WriteLine($"Description: {weatherResponse?.weather[0].main} - {weatherResponse?.weather[0].description}");
        Console.WriteLine();
        Draw.WeatherCondition(weatherResponse?.weather[0].description ?? "Failed");
    }
    catch (Exception e)
    {
        Console.WriteLine("Failed to retrieve weather data. " + e.Message);
    }
    Console.WriteLine();
    Console.WriteLine("Press any key to reset");
    Console.ReadKey();
    Console.Clear();
}
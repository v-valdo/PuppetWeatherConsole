namespace PuppetWeatherConsole;

public class WeatherResponse
{
    public MainData? main { get; set; }
    public List<WeatherDescription> weather { get; set; } = new();
    public string? name { get; set; }
}

public class MainData
{
    public double? temp { get; set; }
    public double? feels_like { get; set; }
}

public class WeatherDescription
{
    public string? main { get; set; }
    public string? description { get; set; }

}

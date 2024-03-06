namespace PuppetWeatherConsole.ASCII;
public class Draw
{
    public static void WeatherCondition(string description)
    {
        if (description.Contains("rain"))
        {
            Rain();
        }
        else if (description.Contains("cloud"))
        {
            Clouds();
        }
    }
    public static void Clouds()
    {
        string cloudPath = "../../../ASCII/Cloudy.txt";

        if (!File.Exists(cloudPath))
        {
            cloudPath = "ASCII/Cloudy.txt";
        }

        string[] clouds = File.ReadAllLines(cloudPath);

        foreach (var line in clouds)
        {
            Console.WriteLine(line);
        }
    }

    public static void Rain()
    {
        string rainPath = "../../../ASCII/Rainy.txt";

        if (!File.Exists(rainPath))
        {
            rainPath = "ASCII/Rainy.txt";
        }

        string[] rain = File.ReadAllLines(rainPath);

        foreach (var line in rain)
        {
            Console.WriteLine(line);
        }
    }
}

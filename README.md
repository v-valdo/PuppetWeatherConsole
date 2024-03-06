# PuppetWeather (Console Version)

educational C# Console App printing *city-specific* and *current* weather data with *OpenWeatherMap API*, SQLite, JsonConverter

## logic
- client retrieves city ID (needed for api request) from the SQLite database, and sends an API request
- json response is deserialized into objects and selected values are printed: temperature, feels_like, and description
- if the description contains "cloud" or "rain" - ascii art is printed accordingly

## notes:
- ParseCities.cs uses a big JSON sample file (bulk.openweathermap.org/sample/daily_14.json.gz) to retrieve city NAME and ID and insert into local SQLite file. It inserts 22 000+ records. The .db file included is already loaded.
- the API key exposed in early commits is obsolete and was used for testing
- this is an unfinished demonstrative project with educational intent

## screenshots
<p align="left">
  <img width="460" height="300" src="https://i.imgur.com/yST12S1.png">
</p>

<p align="left">
  <img width="460" height="300" src="https://i.imgur.com/0drQuYO.png">
</p>

<p align="left">
  <img width="460" height="300" src="https://i.imgur.com/WAgSFhx.png">
</p>

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinalWeather.Models
{
    public class WeatherRepository : IWeatherRepo
    {
        private readonly string _conn; //pull our api key every time we make an api call
        public WeatherRepository(string conn)
        {
            _conn = conn;
        }

        //the city value we will get from the html. at first it will be null and display just the html and when the city is added we will display weather info
        public Weather GetWeather(string City)
        {
            var weatherUrl = "https://api.openweathermap.org/data/2.5/weather?q=" + City + "&units=imperial&appid=" + _conn;
            var weatherClient = new HttpClient();
            var weatherResponse = weatherClient.GetStringAsync(weatherUrl).Result; //won't be succesful at first because City is null. add default?
            var temp = double.Parse(JObject.Parse(weatherResponse)["main"]["temp"].ToString());
            var feelsLike = double.Parse(JObject.Parse(weatherResponse)["main"]["feels_like"].ToString());
            var tempMin = double.Parse(JObject.Parse(weatherResponse)["main"]["temp_min"].ToString());
            var tempMax = double.Parse(JObject.Parse(weatherResponse)["main"]["temp_max"].ToString());
            var icon = JObject.Parse(weatherResponse)["weather"][0]["icon"].ToString();//icon is in index 0 of the weather array
            var country = JObject.Parse(weatherResponse)["sys"]["country"].ToString();
            var lon = double.Parse(JObject.Parse(weatherResponse)["coord"]["lon"].ToString());
            var lat = double.Parse(JObject.Parse(weatherResponse)["coord"]["lat"].ToString());
            var weather = new Weather();
            var coordinates = new Coord();
            coordinates.Longitude = lon;
            coordinates.Latitude = lat;
            weather.Temp = temp;
            weather.FeelsLike = feelsLike;
            weather.City = City;
            weather.TempMin = tempMin;
            weather.TempMax = tempMax;
            weather.Icon = icon;
            weather.Country = country;
            weather.Coordinates = coordinates;
            //create googleMaps weather api
            var key = File.ReadAllText("appsettings.json");
            string mapsKey = JObject.Parse(key).GetValue("GOOGLE").ToString();
            var googleMapsUrl = $"https://www.google.com/maps/embed/v1/view?key={mapsKey}&center={weather.Coordinates.Latitude},{weather.Coordinates.Longitude}&zoom=12&maptype=satellite";
            weather.GoogleMapsUrl = googleMapsUrl;
            return weather;
        }
    }
}

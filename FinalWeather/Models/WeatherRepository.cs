using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            var weather = new Weather();
            weather.Temp = temp;
            weather.FeelsLike = feelsLike;
            weather.City = City;
            weather.TempMin = tempMin;
            weather.TempMax = tempMax;
            weather.Icon = icon;
            return weather;
        }
    }
}

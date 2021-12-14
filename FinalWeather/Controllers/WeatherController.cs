using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalWeather.Models;

namespace FinalWeather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherRepo repo;

        public WeatherController(IWeatherRepo repo)
        {
            this.repo = repo;
        }
        //this is our index method that just returns the view as styled in the index.file of the weather folder.
        public IActionResult Index()
        {
            return View();
        }
        //this is our method that gets the weather and is accessed from the index view of of the home/weather page
        public IActionResult GetWeather(string city)
        {
            var weather = new Weather();
            //this is for the begining when city will be null.
            if (city == null)
            {
                return View(weather);
            }
            try
            {
                //this gets the city for weather and than we return that model
                //if city is passed in than we update the weather model that we are returning to have that city
                weather = repo.GetWeather(char.ToUpper(city[0]) + city.Substring(1)); //This method returns the city to us with the first letter uppercased
                return View(weather);
            }
            catch //If city isn't spelled correctly we get returned to the home page.
            {
                return RedirectToAction("Index", "Weather");
            }
            
        }

        public IActionResult GetWeatherHebrew(string city)
        {
            var weather = new Weather();
            //this is for the begining when city will be null.
            if (city == null)
            {
                return View(weather);
            }
            try
            {
                //this gets the city for weather and than we return that model
                //if city is passed in than we update the weather model that we are returning to have that city
                weather = repo.GetWeather(char.ToUpper(city[0]) + city.Substring(1)); //This method returns the city to us with the first letter uppercased
                return View(weather);
            }
            catch //If city isn't spelled correctly we get returned to the home page.
            {
                return RedirectToAction("Index", "Weather");
            }
            
        }
    }
}

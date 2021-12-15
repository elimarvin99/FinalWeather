using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalWeather.Models
{
    public interface IWeatherRepo
    {
        public Weather GetWeather(string City, string Unit);
    }
}

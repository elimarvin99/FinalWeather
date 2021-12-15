using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalWeather.Models
{
    public class Weather
    {
        public double Temp { get; set; }
        public string City { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public string Icon { get; set; }
        public string Country { get; set; }
        public Coord Coordinates { get; set; }
        public string GoogleMapsUrl { get; set; }
    }
}

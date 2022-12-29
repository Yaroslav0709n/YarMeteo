using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    class WeatherResponse
    {
        public Temperature Main { get; set; }
        public coord coord { get; set; }
        public Weather[] Weather { get; set; }
        public string Name { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        //public Sys Sys { get; set; }
        public string Visibility { get; set; }
    }
}

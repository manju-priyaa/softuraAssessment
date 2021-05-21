using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIWeatherTest4Project
{
    public class Weather
    {
        [Key]
        public string City { get; set; }
        public DateTime Date { get; set; }
        public string LowTemp { get; set; }
        public string HighTemp { get; set; }
        public string  Forecast { get; set; }
    }
}

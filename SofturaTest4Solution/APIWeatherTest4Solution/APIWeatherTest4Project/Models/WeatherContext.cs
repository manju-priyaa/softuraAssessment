using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWeatherTest4Project
{
    public class WeatherContext:DbContext
    {
        public WeatherContext()
        {

        }
        public WeatherContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Weather> Weathers { get; set; }
    }
}

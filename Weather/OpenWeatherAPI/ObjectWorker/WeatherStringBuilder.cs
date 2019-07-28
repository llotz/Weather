using System;
using System.Collections.Generic;
using System.Text;

namespace Weather
{
    public class WeatherStringBuilder
    {
        public string GetBasicWeatherString(string city, string description, double temperature)
        {
            string outputTemplate = "Das Wetter in {0}: {1} bei {2}°C";
            return string.Format(outputTemplate, city, description, temperature);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather
{
    public class WeatherStringBuilder
    {
        private string outputTemplate = "Das Wetter in {0}: {1} bei {2}°C";

        public string GetBasicWeatherString(string city, string description, double temperature)
        {
            return string.Format(outputTemplate, city, description, temperature);
        }
    }
}
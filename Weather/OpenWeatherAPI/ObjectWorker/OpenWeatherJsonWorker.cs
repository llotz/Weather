using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.OpenWeatherAPI
{
    public class OpenWeatherJsonWorker : IOpenWeatherObjectWorker
    {
        private string requestURL = "https://api.openweathermap.org/data/2.5/weather?{0}={1}&lang=de&appid={2}";

        public string GenerateWeatherInfoString(dynamic weatherInfo)
        {
            string description = weatherInfo.weather[0].description;
            string temperature = weatherInfo.main.temp;
            string cityName = weatherInfo.name;
            double temperatureValue = new TemperatureConverter().GetCelsiusTemperature(temperature);
            return new WeatherStringBuilder().GetBasicWeatherString(cityName, description, temperatureValue);
        }

        public dynamic GetDynamicObject(string content)
        {
            return JsonConvert.DeserializeObject(content);
        }

        public string GetRequestUrlByCityName(string cityName)
        {
            string formattedCityName = FormatCityName(cityName);
            return string.Format(requestURL, "q", formattedCityName, Settings.OpenWeatherAPIKey);
        }

        private static string FormatCityName(string cityName)
        {
            return cityName.Replace(" ", "+");
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Weather.OpenWeatherAPI
{
    public class OpenWeatherXmlWorker : IOpenWeatherObjectWorker
    {
        private string requestURL = "https://api.openweathermap.org/data/2.5/weather?{0}={1}&mode=xml&lang=de&appid={2}";

        public string GenerateWeatherInfoString(dynamic weatherInfo)
        {
            string description = weatherInfo.current.weather.@value;
            string temperature = weatherInfo.current.temperature.@value;
            string cityName = weatherInfo.current.city.@name;
            double temperatureValue = new TemperatureConverter().GetCelsiusTemperature(temperature);
            return new WeatherStringBuilder().GetBasicWeatherString(cityName, description, temperatureValue);
        }

        public dynamic GetDynamicObject(string content)
        {
            XDocument doc = XDocument.Parse(content);
            string jsonText = JsonConvert.SerializeXNode(doc);
            return JsonConvert.DeserializeObject(jsonText);
        }

        public string GetRequestUrlByCityName(string cityName)
        {
            return string.Format(requestURL, "q", cityName, Settings.OpenWeatherAPIKey);
        }
    }
}
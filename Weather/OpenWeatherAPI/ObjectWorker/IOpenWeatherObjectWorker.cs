using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.OpenWeatherAPI
{
    public interface IOpenWeatherObjectWorker
    {
        public string GenerateWeatherInfoString(dynamic weatherInfo);

        public dynamic GetDynamicObject(string content);

        public string GetRequestUrlByCityName(string cityName);
    }
}
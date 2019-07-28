using System;
using System.Collections.Generic;
using System.Text;

namespace Weather
{
    public class TemperatureConverter
    {
        public double GetCelsiusTemperature(string weatherTemperature)
        {
            double temperatureValue = ParseToDouble(weatherTemperature);
            temperatureValue = ConvertToCelsius(temperatureValue);
            return temperatureValue;
        }

        private double ParseToDouble(string weatherTemperature)
        {
            weatherTemperature = weatherTemperature.Replace(".", ",");
            double temperatureValue = 0;
            double.TryParse(weatherTemperature, out temperatureValue);
            return temperatureValue;
        }

        private double ConvertToCelsius(double temperatureValue)
        {
            temperatureValue = Math.Round(temperatureValue - 272.15, 0);
            return temperatureValue;
        }
    }
}
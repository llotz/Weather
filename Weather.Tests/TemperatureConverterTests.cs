using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Weather;

namespace Tests
{
    public class TemperatureConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCelsiusTemperature_GiveCommaSeperatedKelvin_GetRoundedCelsiusDouble()
        {
            string kelvin = "275,5";
            TemperatureConverter temperatureConverter = new TemperatureConverter();
            double result = temperatureConverter.GetCelsiusTemperature(kelvin);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void GetCelsiusTemperature_GiveKelvin_GetRoundedCelsiusDouble()
        {
            string kelvin = "275";
            TemperatureConverter temperatureConverter = new TemperatureConverter();
            double result = temperatureConverter.GetCelsiusTemperature(kelvin);
            Assert.AreEqual(3, result);
        }
    }
}
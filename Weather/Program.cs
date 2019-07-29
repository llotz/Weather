using System;
using Newtonsoft.Json;
using Weather.OpenWeatherAPI;

namespace Weather
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            UserInteractor userInteractor = new UserInteractor();
            userInteractor.StartWeatherInteraction();
        }
    }
}
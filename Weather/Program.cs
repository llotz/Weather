using System;
using Newtonsoft.Json;
using Weather.OpenWeatherAPI;

namespace Weather
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            IOpenWeatherObjectWorker openWeatherObjectWorker = new OpenWeatherXmlWorker();

            while (true)
            {
                string cityName = GetCityNameByUserInput();
                string requestUrl = openWeatherObjectWorker.GetRequestUrlByCityName(cityName);
                var webService = CreateWebService(requestUrl);

                if (!ExecuteAPIRequest(webService))
                {
                    WriteNotFoundMessage();
                    continue;
                }

                string jsonContent = GetJsonContent(webService);
                dynamic weatherInfo = openWeatherObjectWorker.GetDynamicObject(jsonContent);
                string weatherInfoString = openWeatherObjectWorker.GenerateWeatherInfoString(weatherInfo);
                Console.WriteLine(weatherInfoString);
            }
        }

        private static void WriteNotFoundMessage()
        {
            Console.WriteLine("Es wurde nichts gefunden.");
        }

        private static string GetCityNameByUserInput()
        {
            Console.WriteLine("Von welcher Stadt soll das Wetter angezeigt werden?");
            string cityName = Console.ReadLine();
            return cityName;
        }

        private static APIWebService CreateWebService(string requestUrl)
        {
            return new APIWebService(requestUrl);
        }

        private static string GetJsonContent(APIWebService webService)
        {
            return webService.GetPageContent();
        }

        private static bool ExecuteAPIRequest(APIWebService webService)
        {
            return webService.Download();
        }
    }
}
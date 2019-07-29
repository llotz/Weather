using System;
using System.Collections.Generic;
using System.Text;
using Weather.OpenWeatherAPI;

namespace Weather
{
    public class UserInteractor
    {
        private IOpenWeatherObjectWorker openWeatherObjectWorker = new OpenWeatherJsonWorker();

        public void StartWeatherInteraction()
        {
            while (true)
            {
                try
                {
                    string cityName = GetCityNameByUserInput();
                    CheckForExit(cityName);
                    string requestUrl = openWeatherObjectWorker.GetRequestUrlByCityName(cityName);
                    string stringContent = GetWeatherFromAPI(requestUrl);
                    if (string.IsNullOrEmpty(stringContent)) continue;
                    dynamic weatherInfo = openWeatherObjectWorker.GetDynamicObject(stringContent);
                    string weatherInfoString = openWeatherObjectWorker.GenerateWeatherInfoString(weatherInfo);
                    Console.WriteLine(weatherInfoString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string GetWeatherFromAPI(string requestUrl)
        {
            var webService = CreateWebService(requestUrl);

            if (!ExecuteAPIRequest(webService))
            {
                WriteNotFoundMessage();
                return null;
            }

            return GetJsonContent(webService);
        }

        private void CheckForExit(string input)
        {
            if (input.Equals("exit"))
                Environment.Exit(0);
        }

        private void WriteNotFoundMessage()
        {
            Console.WriteLine("Der Ort wurde nicht gefunden!");
        }

        private string GetCityNameByUserInput()
        {
            Console.WriteLine("Von welcher Stadt soll das Wetter angezeigt werden?");
            return Console.ReadLine();
        }

        private APIWebService CreateWebService(string requestUrl)
        {
            return new APIWebService(requestUrl);
        }

        private string GetJsonContent(APIWebService webService)
        {
            return webService.GetPageContent();
        }

        private bool ExecuteAPIRequest(APIWebService webService)
        {
            return webService.Execute();
        }
    }
}
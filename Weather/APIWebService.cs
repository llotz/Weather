using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Weather
{
    public class APIWebService
    {
        private RestClient restClient;
        private IRestResponse restResponse = null;

        public APIWebService(string url)
        {
            restClient = new RestClient(url);
        }

        public bool Download()
        {
            restResponse = restClient.Execute(new RestRequest());
            if (restResponse.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public string GetPageContent()
        {
            if (restResponse == null)
                throw new InvalidOperationException("You need to Execute the request before reading the response Content.");
            return restResponse.Content;
        }
    }
}
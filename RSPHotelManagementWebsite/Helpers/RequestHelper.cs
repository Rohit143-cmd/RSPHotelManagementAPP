using log4net;
using RestSharp;
using RSPHotelManagementComman.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSPHotelManagementWebsite.Helpers
{
    public class RequestHelper
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(RequestHelper));
        public static IRestResponse Get(string getURL)
        {
            var baseURL = "https://localhost:44354/api";
            RestClient restClient = new RestClient(baseURL);
            var request = new RestRequest(getURL, Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            var response = restClient.Execute(request);
            return response;
        }
        private static string GetBaseURL()
        {
            return Utility.GetConfigvalue("baseURL");
        }
    }

    
}
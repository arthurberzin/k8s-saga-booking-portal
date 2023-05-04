using CarRent.Application.Interfaces;
using CarRent.Models;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Application
{
    public class OpenCageDataClient : IOpenCageDataClient
    {
        private readonly ILogger _logger;
        private readonly string _apiKey;
        private readonly string _endPointUrl;
        public OpenCageDataClient(string apiKey, string endPointUrl, ILogger logger) 
        {
            _apiKey = apiKey;
            _logger = logger;
            _endPointUrl = endPointUrl;
        }

        public  Location GetLocationByName(string name)
        {
            try
            {
                string url = $"{_endPointUrl}/json?q={WebUtility.UrlEncode(name)}&key={_apiKey}";
                using var webClient = new WebClient();
                string json = webClient.DownloadString(url);
                dynamic data = JObject.Parse(json);
                double lat = data.results[0].geometry.lat;
                double lon = data.results[0].geometry.lng;
                return new Location { Latitude = lat, Longitude = lon };
            }
            catch (Exception ex) 
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
    }
}

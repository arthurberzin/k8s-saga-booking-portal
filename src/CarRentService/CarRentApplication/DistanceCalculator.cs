using CarRent.Application.Interfaces;
using CarRent.Models;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Application
{
    public class DistanceCalculator : IDistanceCalculator
    {
        private IOpenCageDataClient _openCageDataClient;
        public DistanceCalculator(IOpenCageDataClient openCageDataClient)
        {
            _openCageDataClient = openCageDataClient;
        }

        public double CalculateDistance(string location1Name, string location2Name)
        {
            var location1 = _openCageDataClient.GetLocationByName(location1Name);
            if (location1.Item1 == 0  || location1.Item2 == 0)
            {
                throw new Exception($"Could not find location with name '{location1Name}'.");
            }

            var location2 = _openCageDataClient.GetLocationByName(location2Name);
            if (location2.Item1 == 0 || location2.Item2 == 0)
            {
                throw new Exception($"Could not find location with name '{location2Name}'.");
            }

            return CalculateDistance(location1.Item1, location1.Item2, location2.Item1, location2.Item2);
        }
        public double CalculateDistance(Location location1, string location2Name)
        {            
            var location2 = _openCageDataClient.GetLocationByName(location2Name);
            if (location2.Item1 == 0 || location2.Item2 == 0)
            {
                throw new Exception($"Could not find location with name '{location2Name}'.");

            }
            return CalculateDistance(location1.Latitude, location1.Longitude, location2.Item1, location2.Item2);
        }

        public double CalculateDistance(Location location1, Location location2)
        {
            return CalculateDistance(location1.Latitude, location1.Longitude, location2.Latitude, location2.Longitude);
        }

        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Convert latitude and longitude to radians
            double radLat1 = ToRadians(lat1);
            double radLon1 = ToRadians(lon1);
            double radLat2 = ToRadians(lat2);
            double radLon2 = ToRadians(lon2);

            // Calculate the Haversine formula
            double dLat = radLat2 - radLat1;
            double dLon = radLon2 - radLon1;
            double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                       Math.Cos(radLat1) * Math.Cos(radLat2) *
                       Math.Pow(Math.Sin(dLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            const double earthRadiusKm = 6371;
            double distance = earthRadiusKm * c;

            return distance;
        }
        private static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

    }
}

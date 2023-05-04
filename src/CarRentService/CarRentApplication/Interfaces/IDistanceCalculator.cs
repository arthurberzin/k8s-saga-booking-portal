using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Application.Interfaces
{
    public interface IDistanceCalculator
    {
        double CalculateDistance(string location1Name, string location2Name);
        double CalculateDistance(Location location1, string location2Name);
        double CalculateDistance(Location location1, Location location2);
        double CalculateDistance(double lat1, double lon1, double lat2, double lon2);
    }
}

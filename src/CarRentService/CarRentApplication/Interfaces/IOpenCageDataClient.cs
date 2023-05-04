using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Application.Interfaces
{
    public interface IOpenCageDataClient
    {
        Location GetLocationByName(string name);
    }
}

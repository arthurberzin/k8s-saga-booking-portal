using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class Airport
    {
        public Guid Id { get; set; }
        public string AirportCode { get; set; }
        public string AirportName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


        public virtual List<Flight> DepartureFlights { get; set; }
        public virtual List<Flight> ArrivalFlights { get; set; }
    }
}

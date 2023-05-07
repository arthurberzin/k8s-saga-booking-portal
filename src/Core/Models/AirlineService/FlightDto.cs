using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.AirlineService
{
    public class FlightDto
    {
        public string FlightNumber { get; set; }

        public string DepartureAirport { get; set; }
        public string DepartureAirportCity { get; set; }
        public string DepartureAirportCountry { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalAirportCity { get; set; }
        public string ArrivalAirportCountry { get; set; }

        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public TimeSpan FlightDuration  { get; set; }

        public virtual string AircraftNumber { get; set; }
        public virtual string AircraftType { get; set; }
        public virtual int AircraftCapacity { get; set; }
        public virtual int AircraftOccupiedCapacity { get; set; }
    }
}

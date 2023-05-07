using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class Flight
    {
        public Guid Id { get; set; }
        public string FlightNumber { get; set; }

        public Guid AircraftId { get; set; }
        public Guid DepartureAirportId { get; set; }
        public Guid ArrivalAirportId { get; set; }

        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set;}

        public virtual Aircraft Aircraft { get; set; }
        public virtual Airport DepartureAirport { get; set; }
        public virtual Airport ArrivalAirport { get; set; }
        public virtual List<Booking> FlightBookings { get; set; }
        public virtual List<CrewAssignment> Crew { get; set; }
    }
}

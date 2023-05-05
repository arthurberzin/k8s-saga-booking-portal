﻿using System;
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
        public Guid DepartureAirportId { get; set; }
        public Guid ArrivalAirportId { get; set; }
        public virtual Airport DepartureAirport { get; set; }
        public virtual Airport ArrivalAirport { get; set; }

        public string DepartureAirportCode => DepartureAirport.AirportCode;
        public string ArrivalAirportCode => ArrivalAirport.AirportCode;

        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set;}
        public TimeSpan FlightDuration { get; set; }


        public virtual List<AircraftAssignment> AircraftAssignments { get; set; }
        public virtual List<Booking> FlightBookings { get; set; }

        public virtual List<Crew> Crews { get; set; }
    }
}

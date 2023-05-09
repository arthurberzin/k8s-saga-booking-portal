using Airline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Models
{ 
    public class Seat
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string SeatNumber { get; set; }

        public Guid FlightId { get; set; }
        public Guid BookingId { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual Booking Booking { get; set; }
    }
}

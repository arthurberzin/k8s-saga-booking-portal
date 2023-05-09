using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class Booking
    {
        public Guid Id { get; set; } 

        public Guid SeatId { get; set; }
        public virtual Seat Seat { get; set; }
        public string PassengerName { get; set; }
        public DateTime BookingDateTime { get; set; }
    }
}

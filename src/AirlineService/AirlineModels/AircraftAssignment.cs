using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class AircraftAssignment
    {
        public Guid Id { get; set; }

        public Guid AircraftId { get; set; }
        public Guid FlightId { get; set; }
        public virtual Aircraft Aircraft { get; set; }
        public virtual Flight Flight { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

    }
}

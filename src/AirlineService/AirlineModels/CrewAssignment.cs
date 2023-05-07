using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class CrewAssignment
    {
        public Guid Id { get; set; }

        public Guid FlightId { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual Employee Employee { get; set; }

        public CrewRole Role { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        public Guid PositionId { get; set; }
        public Guid CrewId { get; set; }
        public virtual EmployeePosition Position { get; set; }
        public virtual Crew Crew { get; set; }

        public string FirstName { get;set; }
        public string LastName { get; set; }
        public string HireDate { get; set; }
    }
}

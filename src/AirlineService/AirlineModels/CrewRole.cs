using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Models
{
    public enum CrewRole
    {
        [Description("Pilot")]
        Pilot,
        [Description("CoPilot")]
        CoPilot,
        [Description("FlightAttendant")]
        FlightAttendant
    }
}

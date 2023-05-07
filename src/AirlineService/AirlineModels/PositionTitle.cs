using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Models
{
    public enum PositionTitle
    {
        [Description("Flight Attendant")]
        FlightAttendant,
        [Description("Cabin Crew")]
        CabinCrew,
        [Description("Airline Attendant")]
        AirlineAttendant,
        [Description("In-Flight Service Representative")]
        InFlightServiceRepresentative,
        [Description("Airline Steward/Stewardess")]
        AirlineSteward_Stewardess,
        [Description("Flight Crew Member")]
        FlightCrewMember,
        [Description("Flight Service Coordinator")]
        FlightServiceCoordinator,
        [Description("Cabin Attendant")]
        CabinAttendant,
        [Description("Air Hostess/Host")]
        AirHostess_Host,
        [Description("Flight Attendant/In-Flight Supervisor")]
        FlightAttendant_InFlightSupervisor,
        [Description("Pilot")]
        Pilot,
        [Description("Airline Pilot")]
        AirlinePilot,
        [Description("Commercial Pilot")]
        CommercialPilot,
        [Description("First Officer")]
        FirstOfficer,
        [Description("Captain")]
        Captain,
        [Description("Co-Pilot")]
        CoPilot,
        [Description("Flight Crew")]
        FlightCrew,
        [Description("AirAviation Pilot")]
        AviationPilot,
        [Description("Charter Pilot")]
        CharterPilot,
        [Description("Cargo Pilot")]
        CargoPilot,
    }
}

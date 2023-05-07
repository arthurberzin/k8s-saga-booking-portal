using System.ComponentModel;

namespace Airline.Models
{
    public enum DepartmentType
    {
        [Description("In-Flight Services Department")]
        InFlightServicesDepartment,
        [Description("Cabin Services Department")]
        CabinServicesDepartment,
        [Description("Passenger Services Department")]
        PassengerServicesDepartment,
        [Description("Safety and Emergency Procedures Department")]
        SafetyandEmergencyProceduresDepartment,
        [Description("Crew Resources Department")]
        CrewResourcesDepartment,
        [Description("Food and Beverage Services Department")]
        FoodandBeverageServicesDepartment,
        [Description("Uniform and Appearance Department")]
        UniformandAppearanceDepartment,
        [Description("Special Assistance Department")]
        SpecialAssistanceDepartment,
        [Description("Training and Development Department")]
        TrainingandDevelopmentDepartment,
        [Description("Customer Experience Department")]
        CustomerExperienceDepartment,
        [Description("Flight Operations Department")]
        FlightOperationsDepartment,

        [Description("Safety and Training Department")]
        SafetyandTrainingDepartment,
        [Description("Crew Scheduling Department")]
        CrewSchedulingDepartment,
        [Description("Flight Planning Department")]
        FlightPlanningDepartment,
        [Description("Technical Operations Department")]
        TechnicalOperationsDepartment,
        [Description("Aircraft Maintenance Department")]
        AircraftMaintenanceDepartment,
        [Description("Ground Operations Department")]
        GroundOperationsDepartment,
        [Description("Communications Department")]
        CommunicationsDepartment,
        [Description("Quality Assurance Department")]
        QualityAssuranceDepartment,
        [Description("Dispatch Operations Department")]
        DispatchOperationsDepartment
    }
}

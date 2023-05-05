namespace Airline.Models
{
    public class Aircraft
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }
        public AircraftType AircraftType { get; set; }
        public int Capacity { get; set; }

        public virtual List<AircraftAssignment> Assignments { get; set; }
    }
}
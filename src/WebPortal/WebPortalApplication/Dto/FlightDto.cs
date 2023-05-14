namespace WebPortal.Application.Dto
{
    public class FlightDto
    {
        public string FlightNumber { get; set; }
        public double SeatPrice { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureAirportCity { get; set; }
        public string DepartureAirportCountry { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalAirportCity { get; set; }
        public string ArrivalAirportCountry { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public TimeSpan FlightDuration { get; set; }
        public string AircraftNumber { get; set; }
        public string AircraftType { get; set; }
        public int AircraftCapacity { get; set; }
        public int AircraftOccupiedCapacity { get; set; }
    }
}

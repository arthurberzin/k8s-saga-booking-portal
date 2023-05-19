namespace Booking.Models
{
    public class FlightBooking
    {
        public Guid Id { get; set; }   
        public Guid UserId { get; set; }
        public string FlightNumber { get; set; }
        public double Price { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
    }
}
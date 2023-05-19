namespace Booking.Models
{
    public class User
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }

        public virtual List<CarBooking> CarBookings { get; set; }
        public virtual List<FlightBooking> FlightBookings { get; set; }
        public virtual List<HotelBooking> HotelBookings { get; set; }
    }
}
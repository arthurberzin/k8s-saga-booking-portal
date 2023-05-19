namespace Booking.Models
{
    public class HotelBooking
    {
        public Guid Id { get; set; }    
        public Guid UserId { get; set; }
        public Guid HotelId { get; set; }

        public string Address { get; set; }
        public float Price { get; set; }
        public DateTime StartRentDate { get; set; }
        public DateTime CompleteRentDate { get; set; }
    }
}
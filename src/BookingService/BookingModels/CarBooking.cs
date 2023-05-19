namespace Booking.Models
{
    public class CarBooking
    {
        public Guid Id { get; set; }    
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime StartRentDate { get; set; }
        public DateTime CompleteRentDate { get; set; }
    }
}
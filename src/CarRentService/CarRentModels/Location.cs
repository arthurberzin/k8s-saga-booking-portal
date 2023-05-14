namespace CarRent.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;
    }
}
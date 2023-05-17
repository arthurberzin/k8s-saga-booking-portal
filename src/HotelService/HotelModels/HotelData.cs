namespace Hotel.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public float ReviewScore { get; set; }
        public int MaxPeople { get; set; }
        public string Address { get; set; }
        public List<HotelOccupiedDate> OccupiedDates { get; set; }
        public List<HotelImage> Images { get; set; }
        public List<PeriodPrice>? Prices { get; set; }
    }
}
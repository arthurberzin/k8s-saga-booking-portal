namespace Hotel.Models
{
    public class HotelData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float ReviewScore { get; set; }
        public int MaxPeople { get; set; }
        public string Address { get; set; }
        public List<HotelOccupateDate> OccupateDates { get; set; }
        public List<HotelImage> Images { get; set; }
        public List<PeriodPrice>? Prices { get; set; }
    }
}
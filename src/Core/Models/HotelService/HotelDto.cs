namespace Core.Models
{
    public class HotelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float ReviewScore { get; set; }
        public int MaxPeople { get; set; }
        public string Address { get; set; }
        public int[] OccupateDates { get; set; }
        public string[] Images { get; set; }
        public PriceDto[] Prices { get; set; }
    }
}

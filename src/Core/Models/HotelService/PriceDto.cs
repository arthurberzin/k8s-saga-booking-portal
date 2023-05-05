namespace Core.Models
{
    public class PriceDto
    {
        public double Price { get; set; }
        public int FromDay { get; set; } = 0;
        public int ToDay { get; set; } = 0;
    }
}

namespace Hotel.Models
{
    public class PeriodPrice
    {
        public Guid Id { get; set; }
        public double Price { get; set; } 
        public int FromDay { get; set; } = 0;
        public int ToDay { get; set; } = 0;
    }
}
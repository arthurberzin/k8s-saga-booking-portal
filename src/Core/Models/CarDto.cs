namespace Core.Models
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public double Distance { get; set; } // km
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string Transmission { get; set; }
        public int Seats { get; set; }
        public int LargeBag { get; set; }
        public int SmallBag { get; set; }
        public int MileageLimit { get; set; }
        public float PricePerDay { get; set; }
    }
}
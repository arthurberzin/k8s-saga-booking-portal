namespace CarRent.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public Guid CurrentLocationId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public CarType Type { get; set; }
        public TransmissionType Transmission { get; set; }
        public int Seats { get; set; }
        public int LargeBag { get; set; }
        public int SmallBag { get; set; }
        public int MileageLimit { get; set; }
        public float PricePerDay { get; set; }

        public virtual List<CarOccupiedDate> OccupiedDates { get; set; }
        public virtual Location CurrentLocation { get; set; }
    }
}
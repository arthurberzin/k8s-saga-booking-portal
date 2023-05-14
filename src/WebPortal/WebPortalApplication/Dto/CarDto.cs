using System;

namespace WebPortal.Application.Dto
{
    public class CarDto
    {
        public string Id { get; set; }
        public double Distance { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string Transmission { get; set; }
        public int Seats { get; set; }
        public int LargeBag { get; set; }
        public int SmallBag { get; set; }
        public int MileageLimit { get; set; }
        public float PricePerDay { get; set; }
        public List<DateTime> OccupiedDates { get; set; }
    }
}

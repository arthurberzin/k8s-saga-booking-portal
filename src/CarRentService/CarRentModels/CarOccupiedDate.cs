namespace CarRent.Models
{
    public class CarOccupiedDate
    {
        public CarOccupiedDate() { }
        public CarOccupiedDate(DateTime date) : base()
        {
            OccupateDate = date;
        }
        public CarOccupiedDate(int dayOfYear) : base()
        {
            OccupateDate = new DateTime(DateTime.UtcNow.Year, 1, 1).AddDays(dayOfYear - 1); ;
        }
        public CarOccupiedDate(int dayOfYear, string guestName) : this(dayOfYear)
        {
            GuestName = guestName;
        }

        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public DateTime OccupateDate { get; set; }
        public string GuestName { get; set; }
        public int DayOfYear => OccupateDate.DayOfYear;
    }
}
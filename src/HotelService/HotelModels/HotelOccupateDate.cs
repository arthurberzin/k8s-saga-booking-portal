using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class HotelOccupiedDate
    {
        public HotelOccupiedDate() { }
        public HotelOccupiedDate(DateTime date) : base() {
            if (date.Kind != DateTimeKind.Utc)
            {
                date = date.ToUniversalTime();
            }
            OccupateDate = date;
        }
        public HotelOccupiedDate(int dayOfYear) : base() {
            OccupateDate = new DateTime(DateTime.UtcNow.Year, 1, 1).AddDays(dayOfYear - 1);
            if (OccupateDate.Kind != DateTimeKind.Utc)
            {
                OccupateDate = OccupateDate.ToUniversalTime();
            }
        }
        public HotelOccupiedDate(int dayOfYear, string guestName) : this(dayOfYear)
        {
            GuestName = guestName;
        }

        public Guid Id { get; set; }
        public DateTime OccupateDate { get; set; }

        public string GuestName { get; set; }
    }
}

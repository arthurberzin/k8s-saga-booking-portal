using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class HotelOccupateDate
    {
        public HotelOccupateDate() { }
        public HotelOccupateDate(DateTime date) : base() { 
            OccupateDate = date;
        }
        public HotelOccupateDate(int dayOfYear) : base() {
            OccupateDate = new DateTime(DateTime.Now.Year, 1, 1).AddDays(dayOfYear - 1); ;
        }

        public Guid Id { get; set; }
        public DateTime OccupateDate { get; set; }
        public int DayOfYear => OccupateDate.DayOfYear;
    }
}

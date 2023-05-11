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
            OccupateDate = date;
        }
        public HotelOccupiedDate(int dayOfYear) : base() {
            OccupateDate = new DateTime(DateTime.Now.Year, 1, 1).AddDays(dayOfYear - 1); ;
        }

        public Guid Id { get; set; }
        public DateTime OccupateDate { get; set; }
        public int DayOfYear => OccupateDate.DayOfYear;
    }
}

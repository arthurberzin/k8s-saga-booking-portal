using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPortal.Application.Dto
{
    public class HotelDto
    {
        public Guid Id { get;set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float ReviewScore { get; set; }
        public int MaxPeople { get; set; }
        public string Address { get; set; }
        public List<DateTime>  OccupiedDates { get; set; }
        public List<string> Images { get; set; }
        public List<PriceDto> Prices { get;set; }
    }
}

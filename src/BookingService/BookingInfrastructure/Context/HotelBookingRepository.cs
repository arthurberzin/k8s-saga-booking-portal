using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Booking.Models;
using Booking.Application.Interfaces;

namespace Booking.Infrastructure.Context
{
    public class HotelBookingRepository : Repository<HotelBooking>, IHotelBookingRepository
    {
        public HotelBookingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<HotelBooking, bool>> predicate)
        {
            return _dbContext.Set<HotelBooking>().Any(predicate);
        }
    }
}

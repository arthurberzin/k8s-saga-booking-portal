using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Booking.Models;
using Booking.Application.Interfaces;

namespace Booking.Infrastructure.Context
{
    public class CarBookingRepository : Repository<CarBooking>, ICarBookingRepository
    {
        public CarBookingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<CarBooking, bool>> predicate)
        {
            return _dbContext.Set<CarBooking>().Any(predicate);
        }
    }
}

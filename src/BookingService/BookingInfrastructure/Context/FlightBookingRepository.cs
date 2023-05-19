using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Booking.Models;
using Booking.Application.Interfaces;

namespace Booking.Infrastructure.Context
{
    public class FlightBookingRepository : Repository<FlightBooking>, IFlightBookingRepository
    {
        public FlightBookingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<FlightBooking, bool>> predicate)
        {
            return _dbContext.Set<FlightBooking>().Any(predicate);
        }
    }
}

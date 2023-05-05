using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Airline.Models;
using Airline.Application.Interfaces;

namespace Airline.Infrastructure
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<Booking, bool>> predicate)
        {
            return _dbContext.Set<Booking>().Any(predicate);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Airline.Models;
using Airline.Application.Interfaces;

namespace Airline.Infrastructure
{
    public class SeatRepository : Repository<Seat>, ISeatRepository
    {
        public SeatRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<Seat, bool>> predicate)
        {
            return _dbContext.Set<Seat>().Any(predicate);
        }

    }
}

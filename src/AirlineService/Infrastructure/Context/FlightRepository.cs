using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Airline.Models;
using Airline.Application.Interfaces;

namespace Airline.Infrastructure
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<Flight, bool>> predicate)
        {
            return _dbContext.Set<Flight>().Any(predicate);
        }

    }
}

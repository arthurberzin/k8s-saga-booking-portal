using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Airline.Models;
using Airline.Application.Interfaces;

namespace Airline.Infrastructure
{
    public class AirportRepository : Repository<Airport>, IAirportRepository
    {
        public AirportRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<Airport, bool>> predicate)
        {
            return _dbContext.Set<Airport>().Any(predicate);
        }

    }
}

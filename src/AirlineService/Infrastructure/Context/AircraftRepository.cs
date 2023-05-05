using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Airline.Models;
using Airline.Application.Interfaces;

namespace Airline.Infrastructure
{
    public class AircraftRepository : Repository<Aircraft>, IAircraftRepository
    {
        public AircraftRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<Aircraft, bool>> predicate)
        {
            return _dbContext.Set<Aircraft>().Any(predicate);
        }

    }
}

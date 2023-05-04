using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CarRent.Models;
using CarRent.Application.Interfaces;

namespace CarRent.Infrastructure.Context
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<Location, bool>> predicate)
        {
            return _dbContext.Set<Location>().Any(predicate);
        }
    }
}

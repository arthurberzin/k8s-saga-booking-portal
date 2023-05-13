using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CarRent.Models;
using CarRent.Application.Interfaces;

namespace CarRent.Infrastructure.Context
{
    public class CarOccupiedDateRepository : Repository<CarOccupiedDate>, ICarOccupiedDateRepository
    {
        public CarOccupiedDateRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<CarOccupiedDate, bool>> predicate)
        {
            return _dbContext.Set<CarOccupiedDate>().Any(predicate);
        }
    }
}

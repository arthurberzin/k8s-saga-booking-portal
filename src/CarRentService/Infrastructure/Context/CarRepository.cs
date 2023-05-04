using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CarRent.Models;
using CarRent.Application.Interfaces;

namespace CarRent.Infrastructure.Context
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<Car, bool>> predicate)
        {
            return _dbContext.Set<Car>().Any(predicate);
        }

        public async Task<IEnumerable<Car>> GetAllAsync(bool includeLocation = false, CancellationToken cancellationToken = default)
        {
            if (includeLocation)
            {
                return await _dbContext.Set<Car>().Include(it => it.CurrentLocation).ToListAsync(cancellationToken);
            }
            return await base.GetAllAsync(cancellationToken);
        }
    }
}

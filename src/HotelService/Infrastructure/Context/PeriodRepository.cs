using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Hotel.Models;
using Hotel.Application.Interfaces;

namespace Hotel.Infrastructure.Context
{
    public class PeriodRepository : Repository<PeriodPrice>, IPeriodRepository
    {
        public PeriodRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<PeriodPrice, bool>> predicate)
        {
            return _dbContext.Set<PeriodPrice>().Any(predicate);
        }
    }
}

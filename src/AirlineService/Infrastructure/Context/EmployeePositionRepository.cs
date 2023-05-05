using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Airline.Models;
using Airline.Application.Interfaces;

namespace Airline.Infrastructure
{
    public class EmployeePositionRepository : Repository<EmployeePosition>, IEmployeePositionRepository
    {
        public EmployeePositionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<EmployeePosition, bool>> predicate)
        {
            return _dbContext.Set<EmployeePosition>().Any(predicate);
        }

    }
}

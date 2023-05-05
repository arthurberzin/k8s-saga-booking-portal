using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Airline.Models;
using Airline.Application.Interfaces;

namespace Airline.Infrastructure
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<Employee, bool>> predicate)
        {
            return _dbContext.Set<Employee>().Any(predicate);
        }

    }
}

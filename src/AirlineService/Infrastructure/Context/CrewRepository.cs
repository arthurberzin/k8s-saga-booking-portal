using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Airline.Models;
using Airline.Application.Interfaces;

namespace Airline.Infrastructure
{
    public class CrewRepository : Repository<CrewAssignment>, ICrewRepository
    {
        public CrewRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<CrewAssignment, bool>> predicate)
        {
            return _dbContext.Set<CrewAssignment>().Any(predicate);
        }

    }
}

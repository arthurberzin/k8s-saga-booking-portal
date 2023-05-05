using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Airline.Models;
using Airline.Application.Interfaces;

namespace Airline.Infrastructure
{
    public class AircraftAssignmentRepository : Repository<AircraftAssignment>, IAircraftAssignmentRepository
    {
        public AircraftAssignmentRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<AircraftAssignment, bool>> predicate)
        {
            return _dbContext.Set<AircraftAssignment>().Any(predicate);
        }

    }
}

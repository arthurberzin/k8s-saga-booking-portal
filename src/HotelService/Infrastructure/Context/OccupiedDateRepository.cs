using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Hotel.Models;
using Hotel.Application.Interfaces;

namespace Hotel.Infrastructure.Context
{
    public class OccupiedDateRepository : Repository<HotelOccupiedDate>, IOccupiedDateRepository
    {
        public OccupiedDateRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<HotelOccupiedDate, bool>> predicate)
        {
            return _dbContext.Set<HotelOccupiedDate>().Any(predicate);
        }
    }
}

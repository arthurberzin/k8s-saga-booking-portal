using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Hotel.Models;
using Hotel.Application.Interfaces;

namespace Hotel.Infrastructure.Context
{
    public class OccupateDateRepository : Repository<HotelOccupateDate>, IOccupateDateRepository
    {
        public OccupateDateRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<HotelOccupateDate, bool>> predicate)
        {
            return _dbContext.Set<HotelOccupateDate>().Any(predicate);
        }
    }
}

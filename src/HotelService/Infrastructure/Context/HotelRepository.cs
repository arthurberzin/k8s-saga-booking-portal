using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Hotel.Models;
using Hotel.Application.Interfaces;

namespace Hotel.Infrastructure.Context
{
    public class HotelRepository : Repository<HotelData>, IHotelRepository
    {
        public HotelRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<HotelData, bool>> predicate)
        {
            return _dbContext.Set<HotelData>().Any(predicate);
        }
    }
}

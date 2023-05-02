using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Hotel.Models;
using Hotel.Application.Interfaces;

namespace Hotel.Infrastructure.Context
{
    public class HotelImageRepository : Repository<HotelImage>, IHotelImageRepository
    {
        public HotelImageRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<HotelImage, bool>> predicate)
        {
            return _dbContext.Set<HotelImage>().Any(predicate);
        }
    }
}

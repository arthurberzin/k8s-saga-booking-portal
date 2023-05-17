using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Hotel.Models;
using Hotel.Application.Interfaces;

namespace Hotel.Infrastructure.Context
{
    public class HotelRepository : Repository<Models.Hotel>, IHotelRepository
    {
        public HotelRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<Models.Hotel, bool>> predicate)
        {
            return _dbContext.Set<Models.Hotel>().Any(predicate);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Booking.Models;
using Booking.Application.Interfaces;

namespace Booking.Infrastructure.Context
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override bool Exist(Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Set<User>().Any(predicate);
        }
    }
}

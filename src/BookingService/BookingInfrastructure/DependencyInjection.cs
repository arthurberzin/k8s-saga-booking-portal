using Booking.Infrastructure.Context;
using Booking.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Booking.Models;

namespace Booking.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var appOptions = services.BuildServiceProvider().GetRequiredService<IOptions<BookingOptions>>();
            services.AddDbContext<DbContext, ApplicationDbContext>(options => {
                options.UseSqlServer(appOptions.Value.ConnectionString); 
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

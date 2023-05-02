using Hotel.Application.Interfaces;
using Hotel.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DbContext, ApplicationDbContext>(opt => opt.UseInMemoryDatabase("InMen"));

            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IPeriodRepository, PeriodRepository>();
            services.AddScoped<IHotelImageRepository, HotelImageRepository>();
            services.AddScoped<IOccupateDateRepository, OccupateDateRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

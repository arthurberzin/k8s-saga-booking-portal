using CarRent.Application.Interfaces;
using CarRent.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarRent.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DbContext, ApplicationDbContext>(opt => opt.UseInMemoryDatabase("InMen"));

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

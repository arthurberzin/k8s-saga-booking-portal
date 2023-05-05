using Airline.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Airline.Infrastructure
{
    public static class DataPrePopulation
    {
        public static void UseDataPrePopulation(this IApplicationBuilder app)
        {
            using var serciveScope = app.ApplicationServices.CreateScope();
            SeedData(serciveScope.ServiceProvider.GetService<ApplicationDbContext>());
        }

        private static void SeedData(ApplicationDbContext context)
        {
            if (!context.Set<Aircraft>().Any())
            {
                context.Set<Aircraft>().AddRange(
                    new Aircraft
                    {
                        RegistrationNumber = string.Empty,
                    }                   
                );
                context.SaveChanges();
            }
        }
    }
}

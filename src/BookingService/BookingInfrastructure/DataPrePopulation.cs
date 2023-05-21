using Booking.Models;
using Core.Common.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Infrastructure
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
            if (!context.Set<User>().Any())
            {
                context.Set<User>().AddRange(
                    new User { Name = GenerateRandomData.GenerateName()},
                    new User { Name = GenerateRandomData.GenerateName ()},
                    new User { Name = GenerateRandomData.GenerateName ()},
                    new User { Name = GenerateRandomData.GenerateName ()}
                );
                context.SaveChanges();
            }
        }
    }
}

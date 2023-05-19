using Booking.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Infrastructure
{
    public static class DataPrePopulation
    {
        private static readonly string[] FirstNames = { "Alice", "Bob", "Charlie", "Dave", "Eve", "Frank", "Grace", "Heidi", "Ivan", "Jack", "Karen", "Larry", "Megan", "Nancy", "Oliver", "Peter", "Quincy", "Rachel", "Samantha", "Trevor", "Ursula", "Victoria", "Walter", "Xavier", "Yvonne", "Zach" };
        private static readonly string[] LastNames = { "Adams", "Brown", "Carter", "Davis", "Edwards", "Franklin", "Garcia", "Hernandez", "Ishikawa", "Johnson", "Klein", "Lee", "Martin", "Nguyen", "O'Connor", "Patel", "Quinn", "Rivera", "Singh", "Thompson", "Ueda", "Valdez", "Williams", "Xiao", "Yamamoto", "Zhang" };
        private static readonly Random Random = new Random();

        private static string GenerateName()
        {
            string firstName = FirstNames[Random.Next(FirstNames.Length)];
            string lastName = LastNames[Random.Next(LastNames.Length)];
            return $"{firstName} {lastName}";
        }

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
                    new User { Name = GenerateName ()},
                    new User { Name = GenerateName ()},
                    new User { Name = GenerateName ()},
                    new User { Name = GenerateName ()}
                );
                context.SaveChanges();
            }
        }
    }
}

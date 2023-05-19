using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Booking.Infrastructure
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using var appContext = scope.ServiceProvider.GetRequiredService<DbContext>();
                try
                {
                    appContext.Database.Migrate();
                }
                catch
                {
                    throw;
                }
            }
            return webApp;
        }
    }
}

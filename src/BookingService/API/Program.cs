using Booking.Infrastructure;
using Booking.Models;
using Core.Common;
using Core.Common.HealthCheck;

namespace Booking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<BookingOptions>(builder.Configuration.GetSection("ApplicationOptions"));

            builder.Services.AddControllers();
            builder.Host.UseSerilog();

            builder.Services.AddHealthChecks()
                .AddMemoryHealthCheck("Memory")
                .AddDbContextCheck<ApplicationDbContext>();

            builder.Services.AddInfrastructure();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCustomHealthChecks();

            app.MigrateDatabase();
            app.UseDataPrePopulation();

            app.Run();
        }
    }
}
using CarRent.Application.Interfaces;
using CarRent.Infrastructure;
using Core.Common;
using Core.Common.HealthCheck;

namespace CarRent.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Host.UseSerilog();

            builder.Services.AddHealthChecks()
                .AddMemoryHealthCheck("Memory");

            builder.Services.AddInfrastructure();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCustomHealthChecks();

            app.UseDataPrePopulation();

            app.MapGet("/", async (IUnitOfWork unitOfWork, CancellationToken cancellationToken) => {
               
                var res = await unitOfWork.Cars.GetAllAsync(true,cancellationToken);
                return Results.Ok(res.ToList());
            });

            app.Run();
        }
    }
}
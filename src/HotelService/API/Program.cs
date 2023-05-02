using Core.Common;
using Core.Common.HealthCheck;
using Hotel.Application.Interfaces;
using Hotel.Infrastructure;
namespace Hotel.API
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
                    var res = await unitOfWork.Hotels.GetAllAsync(cancellationToken); 
                    return Results.Ok(res.ToList());
                }
            );

            app.Run();
        }
    }
}
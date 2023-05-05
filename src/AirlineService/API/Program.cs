using Airline.Application.Interfaces;
using Airline.Infrastructure;
using Airline.Models;
using AutoMapper;
using Core.Common;
using Core.Common.HealthCheck;
using Core.Models.AirlineService;

namespace Airline.API
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

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddInfrastructure();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCustomHealthChecks();

            app.UseDataPrePopulation();

            app.MapGet("/", async (IUnitOfWork unitOfWork, IMapper mapper, CancellationToken cancellationToken) => {
                var res = await unitOfWork.Aircrafts.GetAllAsync(cancellationToken);
                return Results.Ok(mapper.Map<List<AircraftDto>>(res.ToList()));
            }
);

            app.Run();
        }
    }
}
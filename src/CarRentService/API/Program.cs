using AutoMapper;
using CarRent.Application;
using CarRent.Application.Interfaces;
using CarRent.Infrastructure;
using CarRent.Models;
using Core.Common;
using Core.Common.HealthCheck;
using Core.Models;
using System.Linq;

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

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddInfrastructure();

            builder.Services.AddScoped<IDistanceCalculator, DistanceCalculator>();
            builder.Services.AddScoped<IOpenCageDataClient>(x =>
                new OpenCageDataClient(
                        builder.Configuration.GetValue<string>("OpenCageApiKey"),
                        builder.Configuration.GetValue<string>("OpenCageUrl"),
                        x.GetRequiredService<Serilog.ILogger>()
                    )
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCustomHealthChecks();

            app.UseDataPrePopulation();

            app.MapGet("/", async (IUnitOfWork unitOfWork, IMapper mapper, IDistanceCalculator calculator, IOpenCageDataClient openCageDataClient,CancellationToken cancellationToken) =>
            {

                string destination = "Naples International Airport";
                var destLocation = openCageDataClient.GetLocationByName(destination);
                var res = await unitOfWork.Cars.GetAllAsync(true, cancellationToken);
                return Results.Ok(res.ToList().Select(it => mapper.Map<Car, CarDto>(it, opt =>
                                    opt.AfterMap((src, dest) => dest.Distance = calculator.CalculateDistance(src.CurrentLocation, destLocation)))));
            });

            app.Run();
        }
    }
}
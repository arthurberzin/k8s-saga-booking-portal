using AutoMapper;
using CarRent.Application;
using CarRent.Application.GrpcService;
using CarRent.Application.Interfaces;
using CarRent.Infrastructure;
using CarRent.Models;
using Core.Common;
using Core.Common.HealthCheck;
using Microsoft.Extensions.Options;

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

            builder.Services.Configure<CarRentOptions>(builder.Configuration.GetSection("CarRentOptions"));

            builder.Services.AddHealthChecks()
                .AddMemoryHealthCheck("Memory");

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddInfrastructure();

            builder.Services.AddGrpc();

            builder.Services.AddScoped<IDistanceCalculator, DistanceCalculator>();
            builder.Services.AddScoped<IOpenCageDataClient>(x => {                
                var carRentOptions = x.GetRequiredService<IOptions<CarRentOptions>>();                
                return new OpenCageDataClient(
                        carRentOptions.Value.OpenCageApiKey,
                        carRentOptions.Value.OpenCageUrl,
                        x.GetRequiredService<Serilog.ILogger>()
                    );
                }
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCustomHealthChecks();

            app.UseDataPrePopulation();

            app.MapGrpcService<GrpcCarRentService>();

            app.Run();
        }
    }
}
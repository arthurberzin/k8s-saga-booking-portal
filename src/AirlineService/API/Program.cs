using Airline.Application.GrpcService;
using Airline.Application.Interfaces;
using Airline.Infrastructure;
using Airline.Models;
using AutoMapper;
using Core.Common;
using Core.Common.HealthCheck;
using Grpc.AspNetCore.HealthChecks;
using Grpc.HealthCheck;
using Microsoft.Extensions.DependencyInjection;

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

            builder.Services.AddGrpc();

            builder.Services.AddInfrastructure();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCustomHealthChecks();

            app.UseDataPrePopulation();

            app.MapGrpcService<GrpcAirlineService>();

            app.Run();
        }
    }
}
using Core.Common;
using Core.Common.HealthCheck;
using FluentValidation;
using Hotel.Application.FlitersStrategies;
using Hotel.Application.Grpc;
using Hotel.Application.Grpc.Service;
using Hotel.Application.Interfaces;
using Hotel.Application.Validation;
using Hotel.Infrastructure;
using System.Reflection;

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

            builder.Services.AddGrpc();

            builder.Services.AddScoped<IHotelFilterStrategy, DateHotelFilterStrategy>();
            builder.Services.AddScoped<IValidator<HotelsRequest>, HotelRequestValidator>();

            builder.Services.AddHealthChecks()
                .AddMemoryHealthCheck("Memory");

            builder.Services.AddInfrastructure();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCustomHealthChecks();

            app.UseDataPrePopulation();

            app.MapGrpcService<GrpcHotelService>();

            app.Run();
        }
    }
}
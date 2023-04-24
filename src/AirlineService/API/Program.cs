using Serilog;
using Serilog.Formatting.Compact;

namespace Airline.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Host.UseSerilog((context, config) =>
            {
                config.Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Console()
                .WriteTo.File(new CompactJsonFormatter(), "logs/log.json", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 5)
                .Enrich.WithProperty("Enviroment", context.HostingEnvironment.EnvironmentName)
                .ReadFrom.Configuration(context.Configuration);
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
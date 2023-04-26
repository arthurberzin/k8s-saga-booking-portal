using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;

namespace Core.Common
{
    public static class SerilogHelper
    {
        public static void UseSerilog(this IHostBuilder host)
        {
            host.UseSerilog((context, config) =>
            {
                config.Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Console()
                .WriteTo.File(new CompactJsonFormatter(), "logs/log.json", rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 5)
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                .ReadFrom.Configuration(context.Configuration);
            });
        }
    }
}

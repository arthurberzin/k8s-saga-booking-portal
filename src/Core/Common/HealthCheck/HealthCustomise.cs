using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Core.Models.HealthCheck;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.Common.HealthCheck
{
    public static class HealthCustomise
    {
        public static void UseCustomHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";

                    var response = new HealthCheckResponse
                    {
                        Status = report.Status.ToString(),
                        Checks = report.Entries.Select(it => new HealthCheckItem
                        {
                            Component = it.Key,
                            Status = it.Value.Status.ToString(),
                            Description = it.Value.Description ?? ""
                        }),
                        Duration = report.TotalDuration
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                }
            });
        }
    }
}
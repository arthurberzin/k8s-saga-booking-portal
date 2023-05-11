using Core.Common;
using Core.Common.HealthCheck;
using WebPortal.Application.Grpc;
using WebPortal.Application.Interfaces;
using WebPortal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Host.UseSerilog();

builder.Services.AddHealthChecks()
    .AddMemoryHealthCheck("Memory");


builder.Services.Configure<WebPortalOptions>(builder.Configuration.GetSection("WebPortalOptions"));

builder.Services.AddScoped<IHotelServiceClient, HotelServiceClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCustomHealthChecks();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

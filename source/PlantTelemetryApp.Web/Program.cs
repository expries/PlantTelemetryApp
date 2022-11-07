using FluentValidation;
using NLog;
using NLog.Web;
using PlantTelemetryApp.DataAccess;
using PlantTelemetryApp.DataAccess.Interfaces;
using PlantTelemetryApp.Services;
using PlantTelemetryApp.Services.Interfaces;
using PlantTelemetryApp.Web.Extensions;
using PlantTelemetryApp.Web.Validators;


var logger = LogManager
    .Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

logger.Debug("Init main");

try
{
    var builder = WebApplication.CreateBuilder(args);
    var services = builder.Services;
    var configuration = builder.Configuration;
    
    // Configure logging
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    services.AddControllersWithViews();

    // Configure logging
    services.AddSwaggerGen();

    // Add services
    services.AddTransient<ISensorService, SensorService>();
    services.AddTransient<IMeasurementService, MeasurementService>();

    // Add repositories
    services.AddTransient<ISensorRepository, SensorRepository>();
    services.AddTransient<IMeasurementRepository, MeasurementRepository>();

    // Configure database
    services.ConfigureDatabase(configuration);

    // Add validators
    services.AddValidatorsFromAssemblyContaining<AddMeasurementDtoValidator>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days.
        // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.MapControllers();
    app.UseRouting();
    app.UseAuthorization();
    app.UseAuthentication();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}
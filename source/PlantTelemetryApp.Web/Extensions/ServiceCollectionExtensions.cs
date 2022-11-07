using Microsoft.EntityFrameworkCore;
using PlantTelemetryApp.DataAccess.DbContexts;

namespace PlantTelemetryApp.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TelemetryContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("Database");
            options.UseSqlServer(connectionString);
        });

        var ctx = services.BuildServiceProvider().GetService<TelemetryContext>();
        ctx?.Database.EnsureCreated();
    }
}
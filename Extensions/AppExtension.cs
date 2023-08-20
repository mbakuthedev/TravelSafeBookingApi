using Microsoft.EntityFrameworkCore;
using TravelSafeBookingApi.Data;
using TravelSafeBookingApi.DomainOperations;

namespace TravelSafeBookingApi.Extensions
{
    public static class AppExtension
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetRequiredService<ApplicationDbContext>();
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {

                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError($"An error occured : {ex.Message}");
                }
            }
        }
        public static IServiceCollection AddDomain(this IServiceCollection service)
        {
            service.AddScoped<BusOperations>()
                .AddScoped<RouteOperation>()
                .AddScoped<BusStateOperations>();
            return service;
        }
        public static IServiceCollection ApplyDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options.UseSqlServer(config.GetConnectionString("DefaultConnectionString"),
                        migration => migration.MigrationsAssembly(typeof(Program).Assembly.GetName().Name));
                });
            return services;
        }


    }
}

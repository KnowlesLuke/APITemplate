using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.DbContextSetup
{
    public static class BaseContextConfig
    {
        public static void ConfigureEfDefaults<TContext>(this IServiceCollection services, IConfiguration configuration, string connectionString, bool developmentEnvironment) 
            where TContext : DbContext
        {
            // Add DbContext to the services collection
            services.AddDbContext<TContext>(options =>
            {
                // Use SQL Server and get connection string from appsettings.json - In production, use environment variables
                options.UseSqlServer(configuration.GetConnectionString(connectionString), sqlOptions =>
                {
                    // Set command timeout to 60 seconds and enable retry 3 times on failure
                    sqlOptions.CommandTimeout(30);
                    sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null);
                });

                // No Tracking Ef Core
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                // Log SQL queries in development environment to the console (for debugging & viewing efficiency)
                if (developmentEnvironment)
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.DbContextSetup
{
    public static class Example_APITemplateConfig
    {
        /*
         * Unused Version of ConfigureAPITemplate - Due to multiple Db Contexts, this method is not used
         * Use this if you only have one DbContext in your application
        */

        #warning This method is not used in the project
        public static void ConfigureAPITemplate(this IServiceCollection services, IConfiguration configuration, bool developmentEnvironment)
        {
            services.AddDbContext<APITemplateDbContext>(options =>
            {
                // Use SQL Server and get connection string from appsettings.json - In production, use environment variables
                options.UseSqlServer(configuration.GetConnectionString("APITemplate"), sqlOptions =>
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

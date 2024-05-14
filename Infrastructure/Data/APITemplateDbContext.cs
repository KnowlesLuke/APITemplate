using Domain.BaseEntities.ApiTemplate;
using Domain.Entities.ApiTemplate.Accounts;
using Domain.Entities.ApiTemplate.Assets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class APITemplateDbContext : DbContext
    {
        // Constructor for DbContext
        public APITemplateDbContext(DbContextOptions<APITemplateDbContext> options) : base(options)
        {
        }

        /*
            * Entities are set here for use in Context throughout the app
            * We are ovveriding the default schema for each table using Fluent API in the Configurations Folder
            * Schema can also be set as Data Annotations in the Entity Class - Fluent API is the preferred method
        */

        // Reference to the Account Entity - Accounts.Details Table in Database
        public DbSet<Account> Accounts { get; set; }

        // Reference to the AccountRole Entity - Accounts.Roles Table in Database
        public DbSet<Role> Roles { get; set; }

        // Reference to the Asset Entity - Assets.Details Table in Database
        public DbSet<Asset> Assets { get; set; }

        // Reference to the AssetsType Entity - Assets.Types Table in Database
        public DbSet<AssetType> AssetTypes { get; set; }

        // Reference to the Status Entity - Assets.Status Table in Database
        public DbSet<Status> Status { get; set; }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Set default properties for all strings(nvarchar) and decimals in tables - Can be overridden in the Table Configuration Class

            configurationBuilder.Properties<string>().HaveMaxLength(100);
            configurationBuilder.Properties<decimal>().HavePrecision(16, 2);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Using Fluent API inside config classes to set constraints - Higher Flexibility than using Data Annotations

            // Seperated Configurations for each table - Better for maintainability - Can be found in Configurations Folder
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        // Override SaveChangesAsync to set Modified timestamps for audit
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseTableEntity>().Where(e => e.State == EntityState.Modified);

            // Set Created and Modified timestamps for audit
            foreach (var entry in entries)
            {
                // Set Modified timestamps for audit
                entry.Entity.Modified = DateTime.UtcNow;

                // exit foreach loop
                break;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

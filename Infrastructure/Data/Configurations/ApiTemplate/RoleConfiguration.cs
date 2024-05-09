using Domain.Entities.ApiTemplate.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.ApiTemplate
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Set table name and schema Fluent API
            builder.ToTable("Roles", "Accounts");

            // Set column constraints Fluent API Name
            builder.Property(a => a.Name)
                .IsRequired();

            // Set column constraints Fluent API Description
            builder.Property(a => a.Description)
                .IsRequired();

            // Automatically set filters for all queries (Where Deleted is null)
            builder.HasQueryFilter(a => a.Deleted == null);

            // Seed Data
            builder.HasData(
                new Role { Id = 1, Name = "System Admin", Description = "System Admin AccountRole", CreatedBy = "SeededData" },
                new Role { Id = 2, Name = "Admin", Description = "Admin AccountRole", CreatedBy = "SeededData" },
                new Role { Id = 3, Name = "Guest", Description = "Guest AccountRole", CreatedBy = "SeededData" }
            );
        }
    }
}

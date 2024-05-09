using Domain.Entities.ApiTemplate.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            // Set table name and schema Fluent API
            builder.ToTable("Status", "Assets");

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
                new Status { Id = 1, Name = "Active", Description = "Active Status", CreatedBy = "SeededData" },
                new Status { Id = 2, Name = "Inactive", Description = "Inactive Status", CreatedBy = "SeededData" },
                new Status { Id = 3, Name = "Pending", Description = "Pending Status", CreatedBy = "SeededData" }
            );
        }
    }
}

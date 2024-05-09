using Domain.Entities.ApiTemplate.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.ApiTemplate
{
    internal class AssetTypeConfiguration : IEntityTypeConfiguration<AssetType>
    {
        public void Configure(EntityTypeBuilder<AssetType> builder)
        {
            // Set table name and schema Fluent API
            builder.ToTable("Types", "Assets");

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
                new AssetType { Id = 1, Name = "Laptop", Description = "Laptop Type", CreatedBy = "SeededData" },
                new AssetType { Id = 2, Name = "Desktop", Description = "Desktop Type", CreatedBy = "SeededData" },
                new AssetType { Id = 3, Name = "Mobile", Description = "Mobile Type", CreatedBy = "SeededData" }
            );
        }
    }
}

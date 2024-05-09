using Domain.Entities.ApiTemplate.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.ApiTemplate
{
    internal class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            // Set table name Fluent API - Set schema and temporal table
            builder.ToTable("Details", "Assets", a => a.IsTemporal());

            // Set column constraints Fluent API Name
            builder.Property(a => a.Name)
                .IsRequired();

            // Set column constraints Fluent API Description
            builder.Property(a => a.Description)
                .IsRequired();

            // Set column constraints Fluent API Value
            builder.Property(a => a.Value)
                .IsRequired();

            // Set column constraints Fluent API ReadOnly
            builder.Property(a => a.ReadOnly)
                .HasDefaultValue(false)
                .IsRequired();

            // Set column constraints Fluent API StatusId
            builder.Property(a => a.StatusId)
                .IsRequired();

            // Automatically set filters for all queries (Where Deleted is null)
            builder.HasQueryFilter(a => a.Deleted == null);
        }
    }
}

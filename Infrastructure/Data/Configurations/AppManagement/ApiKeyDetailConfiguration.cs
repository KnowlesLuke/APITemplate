using Domain.Entities.ApiTemplate.Accounts;
using Domain.Entities.AppManagementEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Data.Configurations.AppManagement
{
    internal class ApiKeyDetailConfiguration : IEntityTypeConfiguration<ApiKeyDetail>
    {
        public void Configure(EntityTypeBuilder<ApiKeyDetail> builder)
        {
            // Set table name and schema Fluent API
            builder.ToTable("Details", "ApiKeys");

            // Set constraints for each column in the table
            builder.Property(e => e.AllowedHosts).HasMaxLength(50);

            // Set max length for api key
            builder.Property(e => e.ApiKey).HasMaxLength(256);

            // Set max length for private key
            builder.Property(e => e.PrivateKey)
                    .HasMaxLength(256)
                    .IsUnicode(false);
        }
    }
}

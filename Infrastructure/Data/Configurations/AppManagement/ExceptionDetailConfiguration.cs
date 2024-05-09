using Domain.Entities.AppManagementEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.AppManagement
{
    internal class ExceptionDetailConfiguration : IEntityTypeConfiguration<ExceptionDetail>
    {
        public void Configure(EntityTypeBuilder<ExceptionDetail> builder)
        {
            // Set table name and schema Fluent API
            builder.ToTable("Details", "Exceptions");

            // Set constraints for each column in the table
            builder.Property(e => e.ApplicationName).HasMaxLength(200);
            builder.Property(e => e.ExceptionType).HasMaxLength(511);
        }
    }
}

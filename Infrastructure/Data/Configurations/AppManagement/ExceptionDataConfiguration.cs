using Domain.Entities.ApiTemplate.Accounts;
using Domain.Entities.AppManagementEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Data.Configurations.AppManagement
{
    internal class ExceptionDataConfiguration : IEntityTypeConfiguration<ExceptionData>
    {
        public void Configure(EntityTypeBuilder<ExceptionData> builder)
        {
            // Set table name and schema Fluent API
            builder.ToTable("Data", "Exceptions");
        }
    }
}

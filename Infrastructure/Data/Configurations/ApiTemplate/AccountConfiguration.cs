using Domain.Entities.ApiTemplate.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.ApiTemplate
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            // Set table name and schema Fluent API
            builder.ToTable("Details", "Accounts");

            // Set column constraints Fluent API Forename
            builder.Property(a => a.Forename)
                .IsRequired();

            // Set column constraints Fluent API Surname
            builder.Property(a => a.Surname)
                .IsRequired();

            // Set column constraints Fluent API ApplicationUsername
            builder.Property(a => a.Username)
                .IsRequired();

            // Set column constraints Fluent API Email - Ovveride default max length
            builder.Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(150);

            // Set column constraints Fluent API RoleId
            builder.Property(a => a.RoleId)
                .IsRequired();

            // Automatically set filters for all queries (Where Deleted is null)
            builder.HasQueryFilter(a => a.Deleted == null);

            // Seed Data
            builder.HasData(
                new Account
                {
                    Id = 1,
                    Forename = "John",
                    Surname = "Doe",
                    DisplayName = "John Doe",
                    Username = "TMBC\\John.Doe",
                    Email = "john.doe@tameside.gov.uk",
                    RoleId = 1,
                    CreatedBy = "SeededData"
                }
            );
        }
    }
}

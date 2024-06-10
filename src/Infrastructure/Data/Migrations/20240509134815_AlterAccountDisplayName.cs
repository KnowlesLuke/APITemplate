using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.ApiTemplateMigrations
{
    /// <inheritdoc />
    public partial class AlterAccountDisplayName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                schema: "Accounts",
                table: "Details",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                computedColumnSql: "[Forename] + ' ' + [Surname]",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: "TMBC\\John.Doe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                schema: "Accounts",
                table: "Details",
                newName: "ApplicationUsername");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                schema: "Accounts",
                table: "Details",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComputedColumnSql: "[Forename] + ' ' + [Surname]");

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUsername", "DisplayName" },
                values: new object[] { null, "John Doe" });
        }
    }
}

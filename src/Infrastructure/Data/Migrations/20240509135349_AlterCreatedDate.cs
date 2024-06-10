using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.ApiTemplateMigrations
{
    /// <inheritdoc />
    public partial class AlterCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 9, 14, 53, 49, 501, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 9, 14, 53, 49, 502, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 5, 9, 14, 53, 49, 502, DateTimeKind.Local).AddTicks(3576));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 5, 9, 14, 53, 49, 502, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 9, 14, 53, 49, 502, DateTimeKind.Local).AddTicks(4521));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 5, 9, 14, 53, 49, 502, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 5, 9, 14, 53, 49, 502, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 9, 14, 53, 49, 502, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 5, 9, 14, 53, 49, 502, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 5, 9, 14, 53, 49, 502, DateTimeKind.Local).AddTicks(2525));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

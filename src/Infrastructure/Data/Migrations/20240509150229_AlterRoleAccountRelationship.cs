using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.ApiTemplateMigrations
{
    /// <inheritdoc />
    public partial class AlterRoleAccountRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Details_RoleId",
                schema: "Accounts",
                table: "Details");

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 9, 16, 2, 28, 819, DateTimeKind.Local).AddTicks(658));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 9, 16, 2, 28, 820, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 5, 9, 16, 2, 28, 820, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 5, 9, 16, 2, 28, 820, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 9, 16, 2, 28, 820, DateTimeKind.Local).AddTicks(1576));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 5, 9, 16, 2, 28, 820, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 5, 9, 16, 2, 28, 820, DateTimeKind.Local).AddTicks(1598));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 9, 16, 2, 28, 819, DateTimeKind.Local).AddTicks(8447));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 5, 9, 16, 2, 28, 819, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 5, 9, 16, 2, 28, 819, DateTimeKind.Local).AddTicks(8491));

            migrationBuilder.CreateIndex(
                name: "IX_Details_RoleId",
                schema: "Accounts",
                table: "Details",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Details_RoleId",
                schema: "Accounts",
                table: "Details");

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

            migrationBuilder.CreateIndex(
                name: "IX_Details_RoleId",
                schema: "Accounts",
                table: "Details",
                column: "RoleId",
                unique: true);
        }
    }
}

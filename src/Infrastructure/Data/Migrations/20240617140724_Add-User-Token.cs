using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.ApiTemplateMigrations
{
    /// <inheritdoc />
    public partial class AddUserToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Token",
                schema: "Accounts",
                table: "Details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Token" },
                values: new object[] { new DateTime(2024, 6, 17, 15, 7, 23, 591, DateTimeKind.Local).AddTicks(9164), new Guid("c54941ca-2f86-4a49-85f7-dfb80965a2a4") });

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 17, 15, 7, 23, 592, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 6, 17, 15, 7, 23, 592, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                schema: "Accounts",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 6, 17, 15, 7, 23, 592, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 17, 15, 7, 23, 592, DateTimeKind.Local).AddTicks(7053));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 6, 17, 15, 7, 23, 592, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 6, 17, 15, 7, 23, 592, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 6, 17, 15, 7, 23, 592, DateTimeKind.Local).AddTicks(4560));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 6, 17, 15, 7, 23, 592, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.UpdateData(
                schema: "Assets",
                table: "Types",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 6, 17, 15, 7, 23, 592, DateTimeKind.Local).AddTicks(4587));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
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
        }
    }
}

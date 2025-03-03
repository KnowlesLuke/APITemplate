using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations.APITemplate
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Accounts");

            migrationBuilder.EnsureSchema(
                name: "Assets");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                schema: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, computedColumnSql: "[Forename] + ' ' + [Surname]"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Accounts",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                schema: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Value = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ReadOnly = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    AssetTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    DeletedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Assets",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Details_Types_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalSchema: "Assets",
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.InsertData(
                schema: "Accounts",
                table: "Roles",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "Description", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 3, 9, 36, 23, 749, DateTimeKind.Local).AddTicks(7635), "SeededData", null, null, "System Admin AccountRole", null, null, "System Admin" },
                    { 2, new DateTime(2025, 3, 3, 9, 36, 23, 749, DateTimeKind.Local).AddTicks(7642), "SeededData", null, null, "Admin AccountRole", null, null, "Admin" },
                    { 3, new DateTime(2025, 3, 3, 9, 36, 23, 749, DateTimeKind.Local).AddTicks(7643), "SeededData", null, null, "Guest AccountRole", null, null, "Guest" }
                });

            migrationBuilder.InsertData(
                schema: "Assets",
                table: "Status",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "Description", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 3, 9, 36, 23, 749, DateTimeKind.Local).AddTicks(8314), "SeededData", null, null, "Active Status", null, null, "Active" },
                    { 2, new DateTime(2025, 3, 3, 9, 36, 23, 749, DateTimeKind.Local).AddTicks(8319), "SeededData", null, null, "Inactive Status", null, null, "Inactive" },
                    { 3, new DateTime(2025, 3, 3, 9, 36, 23, 749, DateTimeKind.Local).AddTicks(8321), "SeededData", null, null, "Pending Status", null, null, "Pending" }
                });

            migrationBuilder.InsertData(
                schema: "Assets",
                table: "Types",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "Description", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 3, 9, 36, 23, 749, DateTimeKind.Local).AddTicks(6816), "SeededData", null, null, "Laptop Type", null, null, "Laptop" },
                    { 2, new DateTime(2025, 3, 3, 9, 36, 23, 749, DateTimeKind.Local).AddTicks(6833), "SeededData", null, null, "Desktop Type", null, null, "Desktop" },
                    { 3, new DateTime(2025, 3, 3, 9, 36, 23, 749, DateTimeKind.Local).AddTicks(6835), "SeededData", null, null, "Mobile Type", null, null, "Mobile" }
                });

            migrationBuilder.InsertData(
                schema: "Accounts",
                table: "Details",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "Email", "Forename", "Modified", "ModifiedBy", "RoleId", "Surname", "Token", "Username" },
                values: new object[] { 1, new DateTime(2025, 3, 3, 9, 36, 23, 749, DateTimeKind.Local).AddTicks(3183), "SeededData", null, null, "john.doe@tameside.gov.uk", "John", null, null, 1, "Doe", new Guid("c72b832d-dfef-4ee7-af00-37916e2dcc5b"), "TMBC\\John.Doe" });

            migrationBuilder.CreateIndex(
                name: "IX_Details_RoleId",
                schema: "Accounts",
                table: "Details",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_AssetTypeId",
                schema: "Assets",
                table: "Details",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_StatusId",
                schema: "Assets",
                table: "Details",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "Details",
                schema: "Assets")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "DetailsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Assets")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "Assets");

            migrationBuilder.DropTable(
                name: "Types",
                schema: "Assets");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations.AppManagement
{
    /// <inheritdoc />
    public partial class InitialCreateManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Exceptions");

            migrationBuilder.EnsureSchema(
                name: "ApiKeys");

            migrationBuilder.CreateTable(
                name: "Data",
                schema: "Exceptions",
                columns: table => new
                {
                    ExceptionDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExceptionId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.ExceptionDataId);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                schema: "ApiKeys",
                columns: table => new
                {
                    ApiKeyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivateKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    AllowedHosts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryLimit = table.Column<int>(type: "int", nullable: true),
                    ReadAction = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WriteAction = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.ApiKeyId);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                schema: "Exceptions",
                columns: table => new
                {
                    ExceptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExceptionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HResult = table.Column<int>(type: "int", nullable: true),
                    TargetSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HelpLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerExceptionId = table.Column<int>(type: "int", nullable: true),
                    ApplicationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.ExceptionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data",
                schema: "Exceptions");

            migrationBuilder.DropTable(
                name: "Details",
                schema: "ApiKeys");

            migrationBuilder.DropTable(
                name: "Details",
                schema: "Exceptions");
        }
    }
}

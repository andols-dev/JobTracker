using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobTracker2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    MonthId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.MonthId);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    YearId = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.YearId);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Company = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    MonthId = table.Column<int>(type: "INTEGER", nullable: false),
                    YearId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_Months_MonthId",
                        column: x => x.MonthId,
                        principalTable: "Months",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "YearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearMonths",
                columns: table => new
                {
                    YearMonthId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YearId = table.Column<string>(type: "TEXT", nullable: false),
                    MonthId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearMonths", x => x.YearMonthId);
                    table.ForeignKey(
                        name: "FK_YearMonths_Months_MonthId",
                        column: x => x.MonthId,
                        principalTable: "Months",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YearMonths_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "YearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Months",
                columns: new[] { "MonthId", "Month" },
                values: new object[,]
                {
                    { 1, "January" },
                    { 2, "February" },
                    { 3, "March" },
                    { 4, "April" },
                    { 5, "May" },
                    { 6, "June" },
                    { 7, "July" },
                    { 8, "August" },
                    { 9, "September" },
                    { 10, "October" },
                    { 11, "November" },
                    { 12, "December" }
                });

            migrationBuilder.InsertData(
                table: "Years",
                columns: new[] { "YearId", "Year" },
                values: new object[,]
                {
                    { "2025", 2025 },
                    { "2026", 2026 }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "City", "Company", "Date", "MonthId", "Position", "YearId" },
                values: new object[,]
                {
                    { 1, "New York", "TechCorp", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Software Engineer", "2025" },
                    { 2, "San Francisco", "Innovatech", new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Data Analyst", "2026" }
                });

            migrationBuilder.InsertData(
                table: "YearMonths",
                columns: new[] { "YearMonthId", "MonthId", "YearId" },
                values: new object[,]
                {
                    { 1, 12, "2025" },
                    { 2, 1, "2026" },
                    { 3, 2, "2026" },
                    { 4, 3, "2026" },
                    { 5, 4, "2026" },
                    { 6, 5, "2026" },
                    { 7, 6, "2026" },
                    { 8, 7, "2026" },
                    { 9, 8, "2026" },
                    { 10, 9, "2026" },
                    { 11, 10, "2026" },
                    { 12, 11, "2026" },
                    { 13, 12, "2026" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_MonthId",
                table: "Jobs",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_YearId",
                table: "Jobs",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_YearMonths_MonthId",
                table: "YearMonths",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_YearMonths_YearId",
                table: "YearMonths",
                column: "YearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "YearMonths");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropTable(
                name: "Years");
        }
    }
}

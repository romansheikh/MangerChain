using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InititalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsBonusAdded = table.Column<bool>(type: "bit", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "General Manager" },
                    { 2, "Manager" },
                    { 3, "Office Executive" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "IsBonusAdded", "JoinDate", "ManagerId", "Name", "PositionId", "Salary" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "John", 1, 50000.00m },
                    { 2, true, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ron", 2, 40000.00m },
                    { 6, true, new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mike", 2, 35000.00m },
                    { 3, false, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Jack", 3, 30000.00m },
                    { 4, true, new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Jane", 3, 32000.00m },
                    { 7, false, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Sara", 3, 29000.00m },
                    { 8, true, new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Alex", 3, 31000.00m },
                    { 5, false, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Hun", 3, 28000.00m },
                    { 9, false, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Chris", 3, 27000.00m },
                    { 10, true, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Emily", 3, 32000.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentTemperature = table.Column<double>(type: "float", nullable: false),
                    AverageTemperature = table.Column<double>(type: "float", nullable: false),
                    MaxTemperature = table.Column<double>(type: "float", nullable: false),
                    MinTemperature = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    CityName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tempereture = table.Column<double>(type: "float", nullable: false),
                    ArchiveStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => new { x.CityName, x.Time });
                    table.ForeignKey(
                        name: "FK_Measures_Cities_CityName",
                        column: x => x.CityName,
                        principalTable: "Cities",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}

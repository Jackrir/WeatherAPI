using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddStartData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Name", "AverageTemperature", "CurrentTemperature", "MaxTemperature", "MinTemperature" },
                values: new object[] { "Kharkiv", 24.5, 23.0, 33.0, 15.0 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Name", "AverageTemperature", "CurrentTemperature", "MaxTemperature", "MinTemperature" },
                values: new object[] { "Kiev", 29.0, 29.0, 36.0, 23.0 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Name", "AverageTemperature", "CurrentTemperature", "MaxTemperature", "MinTemperature" },
                values: new object[] { "Lviv", 25.0, 28.0, 38.0, 23.0 });

            migrationBuilder.InsertData(
                table: "Measures",
                columns: new[] { "CityName", "Time", "ArchiveStatus", "Temperature" },
                values: new object[,]
                {
                    { "Kharkiv", new DateTime(2021, 7, 19, 9, 0, 0, 441, DateTimeKind.Unspecified), false, 15.0 },
                    { "Kharkiv", new DateTime(2021, 7, 19, 12, 0, 0, 441, DateTimeKind.Unspecified), false, 26.0 },
                    { "Kharkiv", new DateTime(2021, 7, 19, 15, 0, 0, 441, DateTimeKind.Unspecified), false, 33.0 },
                    { "Kharkiv", new DateTime(2021, 7, 19, 18, 0, 0, 441, DateTimeKind.Unspecified), false, 23.0 },
                    { "Kharkiv", new DateTime(2021, 7, 19, 19, 0, 42, 676, DateTimeKind.Unspecified), true, 10.0 },
                    { "Kharkiv", new DateTime(2021, 7, 19, 19, 10, 42, 676, DateTimeKind.Unspecified), true, 20.0 },
                    { "Kiev", new DateTime(2021, 7, 19, 9, 0, 0, 441, DateTimeKind.Unspecified), false, 23.0 },
                    { "Kiev", new DateTime(2021, 7, 19, 12, 0, 0, 441, DateTimeKind.Unspecified), false, 28.0 },
                    { "Kiev", new DateTime(2021, 7, 19, 15, 0, 0, 441, DateTimeKind.Unspecified), false, 36.0 },
                    { "Kiev", new DateTime(2021, 7, 19, 18, 0, 0, 441, DateTimeKind.Unspecified), false, 29.0 },
                    { "Lviv", new DateTime(2021, 7, 19, 9, 0, 0, 441, DateTimeKind.Unspecified), false, 23.0 },
                    { "Lviv", new DateTime(2021, 7, 19, 12, 0, 0, 441, DateTimeKind.Unspecified), false, 24.0 },
                    { "Lviv", new DateTime(2021, 7, 19, 15, 0, 0, 441, DateTimeKind.Unspecified), false, 28.0 },
                    { "Lviv", new DateTime(2021, 7, 19, 18, 0, 0, 441, DateTimeKind.Unspecified), true, 27.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Kharkiv", new DateTime(2021, 7, 19, 9, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Kharkiv", new DateTime(2021, 7, 19, 12, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Kharkiv", new DateTime(2021, 7, 19, 15, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Kharkiv", new DateTime(2021, 7, 19, 18, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Kharkiv", new DateTime(2021, 7, 19, 19, 0, 42, 676, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Kharkiv", new DateTime(2021, 7, 19, 19, 10, 42, 676, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Kiev", new DateTime(2021, 7, 19, 9, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Kiev", new DateTime(2021, 7, 19, 12, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Kiev", new DateTime(2021, 7, 19, 15, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Kiev", new DateTime(2021, 7, 19, 18, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Lviv", new DateTime(2021, 7, 19, 9, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Lviv", new DateTime(2021, 7, 19, 12, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Lviv", new DateTime(2021, 7, 19, 15, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Measures",
                keyColumns: new[] { "CityName", "Time" },
                keyValues: new object[] { "Lviv", new DateTime(2021, 7, 19, 18, 0, 0, 441, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Name",
                keyValue: "Kharkiv");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Name",
                keyValue: "Kiev");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Name",
                keyValue: "Lviv");
        }
    }
}

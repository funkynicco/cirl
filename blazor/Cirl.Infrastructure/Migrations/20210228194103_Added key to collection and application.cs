using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cirl.Infrastructure.Migrations
{
    public partial class Addedkeytocollectionandapplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Collections",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Applications",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2021, 2, 28, 5, 26, 51, 157, DateTimeKind.Unspecified).AddTicks(4349), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2021, 2, 28, 18, 51, 51, 157, DateTimeKind.Unspecified).AddTicks(5280), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2021, 2, 28, 18, 53, 43, 157, DateTimeKind.Unspecified).AddTicks(5293), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Applications");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2021, 2, 26, 22, 38, 39, 934, DateTimeKind.Unspecified).AddTicks(9295), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2021, 2, 27, 12, 3, 39, 935, DateTimeKind.Unspecified).AddTicks(198), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2021, 2, 27, 12, 5, 31, 935, DateTimeKind.Unspecified).AddTicks(212), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}

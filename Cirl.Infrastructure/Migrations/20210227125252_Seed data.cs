using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cirl.Infrastructure.Migrations
{
    public partial class Seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("74423a21-a8e4-4f09-b60f-baba7602bdd9"), "DefaultCollection" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CollectionId", "Name" },
                values: new object[] { new Guid("16df48d3-4930-44b9-aade-ea975f74c8c0"), new Guid("74423a21-a8e4-4f09-b60f-baba7602bdd9"), "MyApplication" });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "ApplicationId", "Date", "Message", "Severity", "StackTrace" },
                values: new object[] { 1L, new Guid("16df48d3-4930-44b9-aade-ea975f74c8c0"), new DateTimeOffset(new DateTime(2021, 2, 26, 22, 38, 39, 934, DateTimeKind.Unspecified).AddTicks(9295), new TimeSpan(0, 0, 0, 0, 0)), "This is a test", 1, null });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "ApplicationId", "Date", "Message", "Severity", "StackTrace" },
                values: new object[] { 2L, new Guid("16df48d3-4930-44b9-aade-ea975f74c8c0"), new DateTimeOffset(new DateTime(2021, 2, 27, 12, 3, 39, 935, DateTimeKind.Unspecified).AddTicks(198), new TimeSpan(0, 0, 0, 0, 0)), "Something crashed!", 4, null });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "ApplicationId", "Date", "Message", "Severity", "StackTrace" },
                values: new object[] { 3L, new Guid("16df48d3-4930-44b9-aade-ea975f74c8c0"), new DateTimeOffset(new DateTime(2021, 2, 27, 12, 5, 31, 935, DateTimeKind.Unspecified).AddTicks(212), new TimeSpan(0, 0, 0, 0, 0)), "System restored", 2, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("16df48d3-4930-44b9-aade-ea975f74c8c0"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("74423a21-a8e4-4f09-b60f-baba7602bdd9"));
        }
    }
}

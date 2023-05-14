using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class BulkInsertAddedForShareAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EvaUser",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { 1, "johndoe@email.com", "John", "Doe", "johndoe", "password123" },
                    { 2, "bobsmith@email.com", "Bob", "Smith", "bobsmith", "password789" },
                    { 3, "alicejohnson@email.com", "Alice", "Johnson", "alicejohnson", "password1011" }
                });

            migrationBuilder.InsertData(
                table: "Share",
                columns: new[] { "Id", "Description", "Symbol" },
                values: new object[,]
                {
                    { 1, "Apple Inc.", "APL" },
                    { 2, "Amazon.com Inc.", "AMZ" },
                    { 3, "Microsoft Corporation", "MSF" }
                });

            migrationBuilder.InsertData(
                table: "SharePrice",
                columns: new[] { "Id", "Price", "PriceDate", "ShareId" },
                values: new object[,]
                {
                    { 1, 10m, new DateTime(2023, 5, 15, 0, 48, 41, 36, DateTimeKind.Local).AddTicks(2918), 1 },
                    { 2, 20m, new DateTime(2023, 5, 14, 0, 48, 41, 36, DateTimeKind.Local).AddTicks(2928), 1 },
                    { 3, 15m, new DateTime(2023, 5, 15, 0, 48, 41, 36, DateTimeKind.Local).AddTicks(2932), 2 },
                    { 4, 30m, new DateTime(2023, 5, 13, 0, 48, 41, 36, DateTimeKind.Local).AddTicks(2933), 2 },
                    { 5, 10m, new DateTime(2023, 5, 15, 0, 48, 41, 36, DateTimeKind.Local).AddTicks(2935), 3 },
                    { 6, 12m, new DateTime(2023, 5, 13, 0, 48, 41, 36, DateTimeKind.Local).AddTicks(2935), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EvaUser",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EvaUser",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EvaUser",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

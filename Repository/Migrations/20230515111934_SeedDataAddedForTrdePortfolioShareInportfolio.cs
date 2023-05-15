using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class SeedDataAddedForTrdePortfolioShareInportfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Portfolio",
                columns: new[] { "Id", "PortfolioName", "UserId" },
                values: new object[,]
                {
                    { 1, "Joh's Portflio", 1 },
                    { 2, "Bob's Portflio", 2 },
                    { 3, "Alice's Portflio", 3 }
                });

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 1,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 15, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8055), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 2,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 14, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8063), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 3,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 15, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8074), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 4,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 13, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8077), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 5,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 15, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8079), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 6,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 13, 14, 19, 34, 358, DateTimeKind.Unspecified).AddTicks(8081), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Trade",
                columns: new[] { "Id", "Quantity", "ShareId", "TradeDate", "TradePrice", "TradeType", "UserId" },
                values: new object[,]
                {
                    { 1, 20, 1, new DateTime(2023, 5, 15, 14, 19, 34, 359, DateTimeKind.Local).AddTicks(256), 10m, 1, 1 },
                    { 2, 30, 2, new DateTime(2023, 5, 15, 14, 19, 34, 359, DateTimeKind.Local).AddTicks(258), 10m, 1, 1 },
                    { 3, 50, 1, new DateTime(2023, 5, 15, 14, 19, 34, 359, DateTimeKind.Local).AddTicks(260), 15m, 1, 2 },
                    { 4, 60, 2, new DateTime(2023, 5, 15, 14, 19, 34, 359, DateTimeKind.Local).AddTicks(261), 15m, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ShareInPortfolio",
                columns: new[] { "Id", "PortfolioId", "ShareId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 1 },
                    { 4, 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Portfolio",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShareInPortfolio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShareInPortfolio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShareInPortfolio",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShareInPortfolio",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trade",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trade",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trade",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trade",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Portfolio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Portfolio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 1,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 15, 13, 51, 36, 229, DateTimeKind.Unspecified).AddTicks(9648), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 2,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 14, 13, 51, 36, 229, DateTimeKind.Unspecified).AddTicks(9659), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 3,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 15, 13, 51, 36, 229, DateTimeKind.Unspecified).AddTicks(9665), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 4,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 13, 13, 51, 36, 229, DateTimeKind.Unspecified).AddTicks(9667), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 5,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 15, 13, 51, 36, 229, DateTimeKind.Unspecified).AddTicks(9669), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "SharePrice",
                keyColumn: "Id",
                keyValue: 6,
                column: "PriceDate",
                value: new DateTimeOffset(new DateTime(2023, 5, 13, 13, 51, 36, 229, DateTimeKind.Unspecified).AddTicks(9671), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}

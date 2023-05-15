using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class DatabaseCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvaUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Share",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LatestPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Share", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PortfolioName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolio_User_UserId",
                        column: x => x.UserId,
                        principalTable: "EvaUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SharePrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShareId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharePrice_Share_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Share",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ShareId = table.Column<int>(type: "int", nullable: true),
                    TradeType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TradePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TradeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trade_Share_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Share",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trade_User_UserId",
                        column: x => x.UserId,
                        principalTable: "EvaUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShareInPortfolio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: true),
                    ShareId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareInPortfolio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShareInPortfolio_Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShareInPortfolio_Share_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Share",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_UserId",
                table: "Portfolio",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ_Share_Symbol",
                table: "Share",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShareInPortfolio_PortfolioId",
                table: "ShareInPortfolio",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_ShareInPortfolio_ShareId",
                table: "ShareInPortfolio",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_SharePrice_ShareId",
                table: "SharePrice",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_ShareId",
                table: "Trade",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_UserId",
                table: "Trade",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShareInPortfolio");

            migrationBuilder.DropTable(
                name: "SharePrice");

            migrationBuilder.DropTable(
                name: "Trade");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "Share");

            migrationBuilder.DropTable(
                name: "EvaUser");
        }
    }
}

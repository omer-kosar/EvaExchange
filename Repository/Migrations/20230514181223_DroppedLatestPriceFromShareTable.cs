using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class DroppedLatestPriceFromShareTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatestPrice",
                table: "Share");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LatestPrice",
                table: "Share",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

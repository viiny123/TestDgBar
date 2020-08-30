using Microsoft.EntityFrameworkCore.Migrations;

namespace BarDg.Domain.Infra.Migrations
{
    public partial class AddPropPromotionPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PromotionPrice",
                table: "ItemOrders",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionPrice",
                table: "ItemOrders");
        }
    }
}

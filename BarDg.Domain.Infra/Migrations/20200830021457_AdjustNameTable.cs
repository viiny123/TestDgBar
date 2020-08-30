using Microsoft.EntityFrameworkCore.Migrations;

namespace BarDg.Domain.Infra.Migrations
{
    public partial class AdjustNameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Invoices_InvoiceId",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Items_ItemId",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Orders_OrderId",
                table: "ItemOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemOrder",
                table: "ItemOrder");

            migrationBuilder.RenameTable(
                name: "ItemOrder",
                newName: "ItemOrders");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrder_OrderId",
                table: "ItemOrders",
                newName: "IX_ItemOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrder_ItemId",
                table: "ItemOrders",
                newName: "IX_ItemOrders_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrder_InvoiceId",
                table: "ItemOrders",
                newName: "IX_ItemOrders_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrders_Invoices_InvoiceId",
                table: "ItemOrders",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrders_Items_ItemId",
                table: "ItemOrders",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrders_Orders_OrderId",
                table: "ItemOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_Invoices_InvoiceId",
                table: "ItemOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_Items_ItemId",
                table: "ItemOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_Orders_OrderId",
                table: "ItemOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders");

            migrationBuilder.RenameTable(
                name: "ItemOrders",
                newName: "ItemOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrders_OrderId",
                table: "ItemOrder",
                newName: "IX_ItemOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrders_ItemId",
                table: "ItemOrder",
                newName: "IX_ItemOrder_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrders_InvoiceId",
                table: "ItemOrder",
                newName: "IX_ItemOrder_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrder",
                table: "ItemOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Invoices_InvoiceId",
                table: "ItemOrder",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Items_ItemId",
                table: "ItemOrder",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Orders_OrderId",
                table: "ItemOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

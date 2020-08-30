using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarDg.Domain.Infra.Migrations
{
    public partial class AdjustModelingBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_Items_ItemId",
                table: "ItemOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_Orders_OrderId",
                table: "ItemOrders");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders");

            migrationBuilder.RenameTable(
                name: "ItemOrders",
                newName: "ItemOrder");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Clients",
                newName: "Cpf");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrders_OrderId",
                table: "ItemOrder",
                newName: "IX_ItemOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrders_ItemId",
                table: "ItemOrder",
                newName: "IX_ItemOrder_ItemId");

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "ItemOrder",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrder",
                table: "ItemOrder",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrder_InvoiceId",
                table: "ItemOrder",
                column: "InvoiceId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_ItemOrder_InvoiceId",
                table: "ItemOrder");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "ItemOrder");

            migrationBuilder.RenameTable(
                name: "ItemOrder",
                newName: "ItemOrders");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Clients",
                newName: "CPF");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrder_OrderId",
                table: "ItemOrders",
                newName: "IX_ItemOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrder_ItemId",
                table: "ItemOrders",
                newName: "IX_ItemOrders_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => new { x.ItemId, x.InvoiceId });
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarDg.Domain.Infra.Migrations
{
    public partial class SeedItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "UnitPrice" },
                values: new object[] { Guid.NewGuid().ToString(), "Cerveja", 5 });
            
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "UnitPrice" },
                values: new object[] { Guid.NewGuid().ToString(), "Conhaque", 20 });
            
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "UnitPrice" },
                values: new object[] { Guid.NewGuid().ToString(), "Suco", 50 });
            
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "UnitPrice" },
                values: new object[] { Guid.NewGuid().ToString(), "Água", 70 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

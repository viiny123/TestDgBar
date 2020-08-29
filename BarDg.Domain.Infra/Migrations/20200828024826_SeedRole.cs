﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarDg.Domain.Infra.Migrations
{
    public partial class SeedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "administrator", "administrator", Guid.NewGuid().ToString() });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComprASP.Data.Migrations
{
    public partial class Precios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "UsedAt",
                table: "Purchases");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Purchases");

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "Purchases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Purchases",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsedAt",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

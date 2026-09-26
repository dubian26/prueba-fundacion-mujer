using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCatalog.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameStockInicialAndAddFechaModifica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockInicial",
                table: "Productos",
                newName: "Stock");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModifica",
                table: "Productos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                column: "FechaModifica",
                value: new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaModifica",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Productos",
                newName: "StockInicial");
        }
    }
}

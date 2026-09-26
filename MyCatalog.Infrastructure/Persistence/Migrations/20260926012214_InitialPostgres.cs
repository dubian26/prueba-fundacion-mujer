using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCatalog.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Precio = table.Column<int>(type: "integer", nullable: false),
                    StockInicial = table.Column<int>(type: "integer", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "Nombre", "Precio", "StockInicial" },
                values: new object[] { "11111111-1111-1111-1111-111111111111", "Registro inicial para validar la búsqueda por ID.", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Producto de prueba", 1000, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}

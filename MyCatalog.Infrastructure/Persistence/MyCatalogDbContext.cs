using Microsoft.EntityFrameworkCore;
using MyCatalog.Domain.Producto;

namespace MyCatalog.Infrastructure.Persistence;

public sealed class MyCatalogDbContext(DbContextOptions<MyCatalogDbContext> options)
    : DbContext(options)
{
    public DbSet<ProductoRecord> Productos => Set<ProductoRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var producto = modelBuilder.Entity<ProductoRecord>();

        producto.ToTable("Productos");
        producto.HasKey(record => record.Id);
        producto.Property(record => record.Id)
            .HasColumnType("text")
            .ValueGeneratedNever();
        producto.Property(record => record.Nombre).IsRequired();
        producto.Property(record => record.Descripcion).IsRequired();
        producto.Property(record => record.FechaCreacion)
            .HasColumnType("timestamp with time zone");

        producto.HasData(new ProductoRecord
        {
            Id = "11111111-1111-1111-1111-111111111111",
            Nombre = "Producto de prueba",
            Descripcion = "Registro inicial para validar la búsqueda por ID.",
            Precio = 1000,
            StockInicial = 10,
            FechaCreacion = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        });
    }
}

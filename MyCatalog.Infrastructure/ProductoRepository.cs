using Microsoft.EntityFrameworkCore;
using MyCatalog.Domain.Producto;
using MyCatalog.Infrastructure.Persistence;

namespace MyCatalog.Infrastructure;

public sealed class ProductoRepository(
    MyCatalogDbContext context) : IProductoRepository
{
    public async Task<ProductoEntity> BuscarPorId(
        string id,
        CancellationToken cancellationToken)
    {
        var record = await context.Productos
            .AsNoTracking()
            .FirstOrDefaultAsync(
                producto => producto.Id == id,
                cancellationToken);

        return record is null
            ? ProductoEntity.NoExisteEnBD()
            : ProductoEntity.MapearDesdeBD(record);
    }

    public async Task<ProductoEntity> BuscarPorNombre(
        string nombre,
        CancellationToken cancellationToken)
    {
        var record = await context.Productos
            .AsNoTracking()
            .FirstOrDefaultAsync(
                producto => producto.Nombre == nombre,
                cancellationToken);

        return record is null
            ? ProductoEntity.NoExisteEnBD()
            : ProductoEntity.MapearDesdeBD(record);
    }

    public async Task Actualizar(
        ProductoEntity producto,
        CancellationToken cancellationToken)
    {
        var record = await context.Productos
            .FirstOrDefaultAsync(
                p => p.Id == producto.Id,
                cancellationToken) ??
                throw new Exception("El producto no existe.");

        record.Nombre = producto.Nombre;
        record.Descripcion = producto.Descripcion;
        record.Precio = producto.Precio;
        record.Stock = producto.Stock;
        record.FechaModifica = DateTime.UtcNow;
    }

    public async Task Insertar(
        ProductoEntity producto,
        CancellationToken cancellationToken)
    {
        var record = new ProductoRecord
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Descripcion = producto.Descripcion,
            Precio = producto.Precio,
            Stock = producto.Stock,
            FechaCreacion = producto.FechaCreacion,
            FechaModifica = producto.FechaModifica
        };

        await context.Productos.AddAsync(record, cancellationToken);
    }
}

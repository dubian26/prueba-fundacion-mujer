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

    public Task Actualizar(ProductoEntity producto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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
            StockInicial = producto.StockInicial,
            FechaCreacion = producto.FechaCreacion
        };

        await context.Productos.AddAsync(record, cancellationToken);
    }
}

using MyCatalog.Domain.Producto;

namespace MyCatalog.Infrastructure;

public class ProductoRepository : IProductoRepository
{
    public Task<ProductoEntity> BuscarPorId(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ProductoEntity> BuscarPorNombre(string nombre, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Actualizar(ProductoEntity producto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Insertar(ProductoEntity producto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

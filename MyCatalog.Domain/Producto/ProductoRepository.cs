namespace MyCatalog.Domain.Producto;

public interface IProductoRepository
{
    Task<ProductoEntity> BuscarPorId(string id, CancellationToken cancellationToken);
    Task<ProductoEntity> BuscarPorNombre(string nombre, CancellationToken cancellationToken);
    Task Insertar(ProductoEntity producto, CancellationToken cancellationToken);
    Task Actualizar(ProductoEntity producto, CancellationToken cancellationToken);
}

using MyCatalog.Base.Models;

namespace MyCatalog.Domain.Producto;

public interface IProductoRepository
{
    Task<ProductoEntity> BuscarPorId(string id, CancellationToken cancellationToken);
    Task<ProductoEntity> BuscarPorNombre(string nombre, CancellationToken cancellationToken);
    Task<IEnumerable<ProductoEntity>> Listar(SearchParams searchParams, CancellationToken cancellationToken);
    Task<int> TotalReg(CancellationToken cancellationToken);
    Task Insertar(ProductoEntity producto, CancellationToken cancellationToken);
    Task Actualizar(ProductoEntity producto, CancellationToken cancellationToken);
}

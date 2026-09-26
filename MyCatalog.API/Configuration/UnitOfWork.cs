using MyCatalog.Application.Interfaces;
using MyCatalog.Domain.Producto;

namespace MyCatalog.API.Configuration;

public sealed class UnitOfWork(IServiceProvider provider) : IUnitOfWork, IDisposable
{
    private IProductoRepository? _productoRepository;

    public IProductoRepository Producto => _productoRepository ??=
        provider.GetRequiredService<IProductoRepository>();

    public void Commit() => throw new NotImplementedException();

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
using MyCatalog.Application.Interfaces;
using MyCatalog.Domain.Producto;
using MyCatalog.Infrastructure.Persistence;

namespace MyCatalog.API.Configuration;

public sealed class UnitOfWork(
    IServiceProvider provider,
    MyCatalogDbContext context) :
    IUnitOfWork, IDisposable
{
    private IProductoRepository? _productoRepository;

    public IProductoRepository Producto => _productoRepository ??=
        provider.GetRequiredService<IProductoRepository>();

    public void Commit() => context.SaveChanges();
    public void Dispose() => GC.SuppressFinalize(this);
}

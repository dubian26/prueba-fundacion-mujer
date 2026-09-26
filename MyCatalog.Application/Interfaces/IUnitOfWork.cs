using MyCatalog.Domain.Producto;

namespace MyCatalog.Application.Interfaces;

public interface IUnitOfWork
{
    // Listar todos los repositorios que usa el dominio
    public IProductoRepository Producto { get; }

    public void Commit();
    public void Dispose();
}
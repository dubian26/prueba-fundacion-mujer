using MediatR;
using MyCatalog.Application.Interfaces;
using MyCatalog.Base.Models;

namespace MyCatalog.Application.Features.Producto;

public record ProductoNuevoCommand : IRequest<IdResult>
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public int Precio { get; set; }
    public int StockInicial { get; set; }
}

internal class ProductoNuevoHandler(IUnitOfWork unitOfWork) :
   IRequestHandler<ProductoNuevoCommand, IdResult>
{
    public async Task<IdResult> Handle(
       ProductoNuevoCommand request,
       CancellationToken cancellationToken)
    {
        var producto = await unitOfWork.Producto.BuscarPorNombre(
           request.Nombre, cancellationToken);

        producto.ValidarQueNoExistaEnBD();

        producto.Nombre = request.Nombre;
        producto.Descripcion = request.Descripcion;
        producto.Precio = request.Precio;
        producto.StockInicial = request.StockInicial;

        await unitOfWork.Producto.Insertar(
           producto, cancellationToken);

        return new IdResult
        {
            Id = producto.Id,
            Mensaje = "Producto creado con éxito."
        };
    }
}
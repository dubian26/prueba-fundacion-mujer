using MediatR;
using MyCatalog.Application.Interfaces;
using MyCatalog.Domain.Producto;

namespace MyCatalog.Application.Features.Producto;

public record ProductoActualizarStockCommand : IRequest<ProductoDto>
{
    public string Id { get; init; } = string.Empty;
    public int Cantidad { get; init; }
}

internal sealed class ProductoActualizarStockHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<ProductoActualizarStockCommand, ProductoDto>
{
    public async Task<ProductoDto> Handle(
        ProductoActualizarStockCommand request,
        CancellationToken cancellationToken)
    {
        var producto = await unitOfWork.Producto.BuscarPorId(
            request.Id, cancellationToken);

        producto.ValidarQueExistaEnBD();

        var nuevoStock = (long)producto.Stock + request.Cantidad;
        if (nuevoStock > int.MaxValue)
            throw ProductoError.StockSuperaElMaximo();

        producto.Stock = (int)nuevoStock;

        producto.ValidarQueStockNoSeaNegativo();

        await unitOfWork.Producto.Actualizar(
            producto, cancellationToken);

        unitOfWork.Commit();

        return ProductoDto.MapearDesde(producto);
    }
}

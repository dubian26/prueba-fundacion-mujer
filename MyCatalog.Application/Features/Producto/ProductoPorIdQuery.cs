using MediatR;
using MyCatalog.Application.Interfaces;
using MyCatalog.Base.Models;

namespace MyCatalog.Application.Features.Producto;

public record ProductoPorIdQuery : IRequest<Result<ProductoDto>>
{
    public string Id { get; init; } = string.Empty;
}

internal class ProductoPorIdHandler(IUnitOfWork unitOfWork) :
   IRequestHandler<ProductoPorIdQuery, Result<ProductoDto>>
{
    public async Task<Result<ProductoDto>> Handle(
       ProductoPorIdQuery request,
       CancellationToken cancellationToken)
    {
        var producto = await unitOfWork.Producto.BuscarPorId(
           request.Id, cancellationToken);

        if (!producto.ExisteEnBD)
            return Result<ProductoDto>.Empty();

        var dto = ProductoDto.MapearDesde(producto);
        var result = new Result<ProductoDto>(dto);

        return result;
    }
}

using MediatR;
using MyCatalog.Application.Interfaces;
using MyCatalog.Base.Models;

namespace MyCatalog.Application.Features.Producto;

public record ProductoListarQuery :
    SearchParams, IRequest<Result<ProductoDto>>;

internal sealed class ProductoListarQueryHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<ProductoListarQuery, Result<ProductoDto>>
{
    public async Task<Result<ProductoDto>> Handle(
        ProductoListarQuery request,
        CancellationToken cancellationToken)
    {
        var totalReg = await unitOfWork.Producto.TotalReg(
            cancellationToken);

        var productos = await unitOfWork.Producto.Listar(
            request, cancellationToken);

        var data = productos.Select(ProductoDto.MapearDesde);

        return new Result<ProductoDto>(data, totalReg);
    }
}

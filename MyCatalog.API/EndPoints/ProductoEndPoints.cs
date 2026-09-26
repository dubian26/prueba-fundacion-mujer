using MediatR;
using MyCatalog.Application.Features.Producto;

namespace MyCatalog.API.EndPoints;

public static class ProductoEndPoints
{
    public static void MapProductoEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/v1/productos/buscar-por-id", async (
           ProductoPorIdQuery request, ISender sender,
           CancellationToken cancellationToken) =>
        {
            ArgumentNullException.ThrowIfNull(request);
            return await sender.Send(request, cancellationToken);
        });

        app.MapPost("/v1/productos/crear", async (
           ProductoNuevoCommand request, ISender sender,
           CancellationToken cancellationToken) =>
        {
            ArgumentNullException.ThrowIfNull(request);
            return await sender.Send(request, cancellationToken);
        });
    }
}
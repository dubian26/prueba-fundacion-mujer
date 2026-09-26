using MediatR;
using MyCatalog.Application.Features.Producto;

namespace MyCatalog.API.EndPoints;

public static class ProductoEndPoints
{
    public static void MapProductoEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/products/{id}", async (
            string id, ISender sender,
            CancellationToken cancellationToken) =>
        {
            ProductoPorIdQuery request = new() { Id = id };
            return await sender.Send(request, cancellationToken);
        });

        app.MapPatch("/v1/products/{id}/stock", async (
            string id,
            ProductoActualizarStockCommand command,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            return await sender.Send(
                command with { Id = id },
                cancellationToken);
        });

        app.MapPost("/v1/products", async (
            ProductoNuevoCommand request, ISender sender,
            CancellationToken cancellationToken) =>
        {
            ArgumentNullException.ThrowIfNull(request);
            return await sender.Send(request, cancellationToken);
        });
    }
}

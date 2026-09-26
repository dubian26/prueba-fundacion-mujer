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
        })
        .WithName("ObtenerProductoPorId")
        .WithTags("Productos")
        .WithSummary("Consulta un producto por su identificador")
        .WithDescription("Devuelve el resultado de la búsqueda del producto indicado.");

        app.MapGet("/v1/products", async (
            int skip,
            int take,
            string? search,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            ProductoListarQuery request = new()
            {
                Skip = skip,
                Take = take,
                Search = search
            };

            return await sender.Send(request, cancellationToken);
        })
        .WithName("ListarProductos")
        .WithTags("Productos")
        .WithSummary("Lista productos con paginación y búsqueda")
        .WithDescription("skip indica cuántos productos omitir y take cuántos devolver. search, si se proporciona, busca sin distinguir mayúsculas en el nombre y la descripción. TotalReg informa el total de coincidencias antes de paginar.");

        app.MapPatch("/v1/products/actualizar-stock", async (
            ProductoActualizarStockCommand command,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            return await sender.Send(command, cancellationToken);
        })
        .WithName("ActualizarStockProducto")
        .WithTags("Productos")
        .WithSummary("Actualiza el stock de un producto")
        .WithDescription("El ID del producto y la cantidad se envían en el body. Una cantidad positiva suma unidades y una negativa las descuenta; el stock no puede quedar por debajo de cero.");

        app.MapPost("/v1/products", async (
            ProductoNuevoCommand request, ISender sender,
            CancellationToken cancellationToken) =>
        {
            ArgumentNullException.ThrowIfNull(request);
            return await sender.Send(request, cancellationToken);
        })
        .WithName("CrearProducto")
        .WithTags("Productos")
        .WithSummary("Crea un producto")
        .WithDescription("Registra un producto con su nombre, descripción, precio y stock inicial.");
    }
}

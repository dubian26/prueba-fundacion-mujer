using MyCatalog.Domain.Producto;

namespace MyCatalog.Application.Features.Producto;

public record ProductoDto
{
    public string Id { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public int Precio { get; set; }
    public int Stock { get; set; }
    public string FechaCreacion { get; set; } = string.Empty;

    public static ProductoDto MapearDesde(ProductoEntity producto)
    {
        if (producto is null) return null!;

        return new ProductoDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Descripcion = producto.Descripcion,
            Precio = producto.Precio,
            Stock = producto.Stock,
            FechaCreacion = producto.FechaCreacion.ToString("s")
        };
    }
}

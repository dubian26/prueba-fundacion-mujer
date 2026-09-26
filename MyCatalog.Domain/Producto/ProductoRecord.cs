namespace MyCatalog.Domain.Producto;

public record ProductoRecord
{
    public string Id { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public int Precio { get; set; }
    public int StockInicial { get; set; }
    public string FechaCreacion { get; set; } = string.Empty;
}

namespace MyCatalog.Base.Models;

public record DataProp
{
   public required string Nombre { get; init; }
   public string? Alias { get; init; }
   public object? ValorActual { get; set; }
   public object? ValorNuevo { get; set; }
   public string? ValorActualCadena { get; set; }
   public string? ValorNuevoCadena { get; set; }
}

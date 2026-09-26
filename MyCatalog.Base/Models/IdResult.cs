namespace MyCatalog.Base.Models;

public record IdResult
{
   public required string Id { get; init; }
   public string Mensaje { get; init; } = string.Empty;
}

namespace MyCatalog.Base.Models;

public record class ErrorDetail
{
   public required string PropertyName { get; init; }
   public required string Message { get; init; }
}

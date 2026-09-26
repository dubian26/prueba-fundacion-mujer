namespace MyCatalog.Base.Models;

public record class ErrorMessage
{
   public required string Type { get; init;}
   public required string Code { get; init; }
   public required string Message { get; init; }
   public string? TraceId { get; init; } = null;
   public IEnumerable<ErrorDetail> Details { get; set; } = [];
}

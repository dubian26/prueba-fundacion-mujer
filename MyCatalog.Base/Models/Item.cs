namespace MyCatalog.Base.Models;

public record Item
{
   public required string Id { get; init; }
   public required string Label { get; init; }
   public IEnumerable<Item> Children { get; init; } = [];
}

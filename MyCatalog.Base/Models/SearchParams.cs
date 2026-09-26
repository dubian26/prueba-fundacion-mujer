namespace MyCatalog.Base.Models;

public record SearchParams
{
    public int Skip { get; init; }
    public int Take { get; init; }
    public string? Search { get; init; }
}

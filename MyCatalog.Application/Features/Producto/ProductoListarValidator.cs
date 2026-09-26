using FluentValidation;

namespace MyCatalog.Application.Features.Producto;

public sealed class ProductoListarValidator :
    AbstractValidator<ProductoListarQuery>
{
    public ProductoListarValidator()
    {
        RuleFor(query => query.Skip)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Skip no puede ser negativo.");

        RuleFor(query => query.Take)
            .GreaterThan(0)
            .WithMessage("Take debe ser mayor que cero.");

        RuleFor(query => query.Search)
            .Matches("""^[\p{L}\p{M}\p{N} .,;:!?¡¿'"()_/#&+\-@$€]+$""")
            .WithMessage("Search solo puede contener letras, números, espacios y símbolos comunes.")
            .When(query => !string.IsNullOrWhiteSpace(query.Search));
    }
}

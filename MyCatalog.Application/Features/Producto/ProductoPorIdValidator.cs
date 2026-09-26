using FluentValidation;

namespace MyCatalog.Application.Features.Producto;

public sealed class ProductoPorIdValidator : AbstractValidator<ProductoPorIdQuery>
{
    public ProductoPorIdValidator()
    {
        RuleFor(query => query.Id)
            .Must(id => Guid.TryParse(id, out _))
            .WithMessage("El ID del producto debe tener un formato GUID válido.");
    }
}

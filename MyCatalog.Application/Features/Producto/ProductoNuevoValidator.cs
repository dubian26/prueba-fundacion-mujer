using FluentValidation;

namespace MyCatalog.Application.Features.Producto;

public sealed class ProductoNuevoValidator : AbstractValidator<ProductoNuevoCommand>
{
    public ProductoNuevoValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty()
            .WithMessage("El nombre del producto es obligatorio.")
            .Length(3, 100)
            .WithMessage("El nombre del producto debe tener entre 3 y 100 caracteres.");

        RuleFor(x => x.Descripcion)
            .NotEmpty()
            .WithMessage("La descripción del producto es obligatoria.")
            .Length(10, 200)
            .WithMessage("La descripción del producto debe tener entre 10 y 200 caracteres.");

        RuleFor(x => x.Precio)
            .GreaterThan(0)
            .WithMessage("El precio debe ser mayor que cero.");

        RuleFor(x => x.StockInicial)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El stock inicial no puede ser negativo.");
    }
}

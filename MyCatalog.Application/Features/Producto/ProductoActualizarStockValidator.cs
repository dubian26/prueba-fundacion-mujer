using FluentValidation;

namespace MyCatalog.Application.Features.Producto;

public sealed class ProductoActualizarStockValidator :
    AbstractValidator<ProductoActualizarStockCommand>
{
    private const int CantidadMaximaPorAjuste = 1_000_000;

    public ProductoActualizarStockValidator()
    {
        RuleFor(command => command.Id)
            .Must(id => Guid.TryParse(id, out _))
            .WithMessage("El ID del producto debe tener un formato GUID válido.");

        RuleFor(command => command.Cantidad)
            .Cascade(CascadeMode.Stop)
            .NotEqual(0)
            .WithMessage("La cantidad a sumar o restar no puede ser cero.")
            .InclusiveBetween(-CantidadMaximaPorAjuste, CantidadMaximaPorAjuste)
            .WithMessage($"La cantidad por ajuste debe estar entre {-CantidadMaximaPorAjuste} y {CantidadMaximaPorAjuste}.");
    }
}

using FluentValidation;
using MediatR;
using MyCatalog.Base.Exceptions;
using MyCatalog.Base.Models;

namespace MyCatalog.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var failures = new List<ErrorDetail>();

        foreach (var validator in validators)
        {
            var context = new ValidationContext<TRequest>(request);
            var result = await validator.ValidateAsync(context, cancellationToken);

            failures.AddRange(
                result.Errors.Select(f => new ErrorDetail
                {
                    PropertyName = f.PropertyName,
                    Message = f.ErrorMessage
                }));
        }

        if (failures.Count > 0)
            throw ExBase.ErrorDatosEntrada(
                message: "Datos de entrada no válidos.",
                details: failures);

        return await next(cancellationToken);
    }
}

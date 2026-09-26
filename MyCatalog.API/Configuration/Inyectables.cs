using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MyCatalog.Application.Behaviors;
using MyCatalog.Application.Features.Producto;
using MyCatalog.Application.Interfaces;
using MyCatalog.Base.Exceptions;
using MyCatalog.Base.Interfaces;
using MyCatalog.Base.ValueObjects;
using MyCatalog.Domain.Producto;
using MyCatalog.Infrastructure;
using MyCatalog.Infrastructure.Persistence;

namespace MyCatalog.API.Configuration;

public static class Inyectables
{
    public static void AgregarDependencias(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var assembly = typeof(IAssemblyRef).Assembly;
        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(assembly);
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddTransient<IErrorHandler, ErrorHandler>();
        services.AddScoped(provider => InfoUsuario.CrearAnonimo());

        var connectionString = configuration.GetConnectionString("MyCatalog")
            ?? throw new InvalidOperationException(
                "No se configuró la cadena de conexión 'MyCatalog'.");

        services.AddDbContext<MyCatalogDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Registrar repositorios
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductoRepository, ProductoRepository>();
    }
}

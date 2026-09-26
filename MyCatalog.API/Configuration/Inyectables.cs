using MyCatalog.Base.Exceptions;
using MyCatalog.Base.Interfaces;
using MyCatalog.Base.ValueObjects;
using MyCatalog.Domain.Producto;
using MyCatalog.Infrastructure;

namespace MyCatalog.API.Configuration;

public static class Inyectables
{
    public static void AgregarDependencias(this IServiceCollection services)
    {
        var assembly = typeof(Inyectables).Assembly;
        services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));

        services.AddTransient<IErrorHandler, ErrorHandler>();
        services.AddScoped(provider => InfoUsuario.CrearAnonimo());

        // Registrar repositorios
        services.AddScoped<UnitOfWork>();
        services.AddTransient<IProductoRepository, ProductoRepository>();
    }
}

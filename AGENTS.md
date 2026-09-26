# Guía del repositorio

- La solución es `PruebaFundacionMujer.slnx`; los cinco proyectos apuntan a `net10.0`. No hay `global.json`: usa el SDK de .NET 10.
- Mantén la dirección de dependencias de Clean Architecture: `API → Application/Infrastructure → Domain → Base`. `MyCatalog.Base` es la biblioteca transversal para tipos y utilidades compartidos; evita poner lógica propia de una capa allí. La referencia directa actual a Base está en Domain.
- `MyCatalog.API` es el punto de entrada: `Program.cs` configura el host, `Configuration/Inyectables.cs` registra dependencias y `EndPoints/` expone rutas. Application contiene casos de uso; Domain, modelo y contratos del dominio; Infrastructure, implementaciones externas.
- Mantén el flujo de casos de uso: Endpoint → Query/Command → MediatR → `ValidationBehavior` → Handler. Los validators de FluentValidation validan datos de entrada antes de ejecutar el Handler.
- El Handler debe orquestar, no concentrar reglas de negocio. Usa `IUnitOfWork` y sus repositorios para persistencia; llama a `Commit()` después de una operación de escritura.
- Las entidades del dominio concentran las reglas de negocio y pueden lanzar `CustomException`. No dupliques esas reglas en handlers o repositorios.
- Las excepciones se centralizan en `ErrorMiddleware` y `ErrorHandler`, que traducen errores controlados y no controlados a la respuesta de error de la API.
- Infrastructure implementa los contratos de repositorio del dominio con Entity Framework Core y PostgreSQL; conserva el uso de `ProductoRecord` para persistencia en lugar de mapear directamente las entidades del dominio.
- Compila la solución con `dotnet build PruebaFundacionMujer.slnx` y ejecuta la API con `dotnet run --project MyCatalog.API/MyCatalog.API.csproj`.
- Aún no hay proyectos de pruebas; `dotnet test` no verifica comportamiento hasta que se agreguen.

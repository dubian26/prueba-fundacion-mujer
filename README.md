# Prueba técnica: Fundación de la Mujer

Prueba técnica para aplicar al cargo de Desarrollador Backend en Fundación de la Mujer.

## Arquitectura

La solución usa una variante de Clean Architecture. El flujo de una petición es:

**Endpoint → Query/Command → MediatR → `ValidationBehavior` → Handler → `IUnitOfWork`/repositorio → infraestructura de datos.**

- Las **Queries y Commands** representan casos de uso y MediatR los envía a su Handler.
- `ValidationBehavior` ejecuta los validators de FluentValidation antes del Handler. Los errores de entrada se convierten en `CustomException`.
- El **Handler orquesta** el caso de uso y usa `IUnitOfWork` para acceder a los repositorios y confirmar cambios.
- Las **entidades del dominio** concentran las reglas de negocio; pueden lanzar `CustomException` cuando los datos incumplen esas reglas.
- **Infrastructure** implementa el acceso a PostgreSQL con Entity Framework Core. `ErrorMiddleware` y `ErrorHandler` procesan globalmente las excepciones y preparan la respuesta de error.

## Ejecutar y probar

### Opción recomendada: Docker

Requisitos: Docker Engine y Docker Compose v2.

Desde la raíz del repositorio, iniciar la API y PostgreSQL:

```bash
docker compose up --build
```

La API queda disponible en `http://localhost:8080`. Al iniciar, aplica las migraciones pendientes y carga un producto de prueba con este ID:

```text
11111111-1111-1111-1111-111111111111
```

Buscar el producto de prueba:

```bash
curl http://localhost:8080/v1/products/11111111-1111-1111-1111-111111111111
```

Crear un producto:

```bash
curl -X POST http://localhost:8080/v1/products \
  -H "Content-Type: application/json" \
  -d '{"nombre":"Producto 1","descripcion":"Descripción del producto 1","precio":100,"stockInicial":10}'
```

Detener los servicios sin borrar los datos:

```bash
docker compose down
```

Para borrar también los datos de PostgreSQL, usar `docker compose down -v`.

### Alternativa: ejecutar la API localmente

Requisitos: .NET SDK 10, Docker Engine y Docker Compose v2.

Desde la raíz, iniciar PostgreSQL:

```bash
docker compose up -d postgres
```

En otra terminal, desde la raíz, ejecutar la API con el perfil HTTPS:

```bash
dotnet run --project MyCatalog.API/MyCatalog.API.csproj --launch-profile https
```

La API queda disponible en `https://localhost:7089`. Para probarla, usar los mismos `curl` de arriba y reemplazar `http://localhost:8080` por `https://localhost:7089`.

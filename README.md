# Prueba técnica: Fundación de la Mujer

Prueba técnica para aplicar al cargo de Desarrollador Backend en Fundación de la Mujer.

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

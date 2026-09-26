using MyCatalog.API.Configuration;
using MyCatalog.API.EndPoints;
using Microsoft.EntityFrameworkCore;
using MyCatalog.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("v1", new()
    {
        Title = "MyCatalog API",
        Version = "v1",
        Description = "API para consultar y administrar productos."
    }));

builder.Services.AgregarDependencias(builder.Configuration);

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyCatalogDbContext>();
    await dbContext.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint(
            url: "/swagger/v1/swagger.json",
            name: "MyCatalog API v1"));

    app.MapOpenApi();
}

//app.UseHttpsRedirection();
//app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();
app.MapProductoEndPoints();

await app.RunAsync();

using MyCatalog.API.Configuration;
using MyCatalog.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AgregarDependencias();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.MapOpenApi();

//app.UseHttpsRedirection();
//app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();
app.MapProductoEndPoints();

app.Run();

using MyCatalog.Base.Interfaces;
using System.Net;

namespace MyCatalog.API.Configuration;

public class ErrorMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(
       HttpContext context,
       IErrorHandler errorHandler)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var errorMessage = errorHandler.Generar(ex);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
            await context.Response.WriteAsJsonAsync(errorMessage);
        }
    }
}

using Microsoft.Extensions.Logging;
using MyCatalog.Base.Interfaces;
using MyCatalog.Base.Models;

namespace MyCatalog.Base.Exceptions;

public class ErrorHandler(ILogger<ErrorHandler> logger) : IErrorHandler
{
   public ErrorMessage Generar(Exception ex)
   {
      string traceId = Guid.NewGuid().ToString();
      logger.LogDebug("Error interno: {TraceId}", traceId);

      if (ex is CustomException customEx) {
         logger.LogWarning(
            exception: customEx,
            message: customEx.Message);

         return new() {
            Type = "Custom",
            TraceId = traceId,
            Code = $"{customEx.DeclaringType}.{customEx.MethodName}",
            Message = customEx.Message
         };
      }

      logger.LogError(
         exception: ex,
         message: "Error interno: {TraceId}", traceId);

      return new() {
         Type = "NoControl",
         TraceId = traceId,
         Code = "ExBase.NoControl",
         Message = $"Error interno: {traceId}"
      };
   }
}

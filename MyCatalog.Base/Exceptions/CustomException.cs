using System.Reflection;
using MyCatalog.Base.Models;

namespace MyCatalog.Base.Exceptions;

public class CustomException : Exception
{
   public CustomException(
      MethodBase methodInfo, string message,
      string? propertyName = null,
      IEnumerable<ErrorDetail>? details = null) : base(message)
   {
      DeclaringType = methodInfo.DeclaringType?.Name ?? string.Empty;
      MethodName = methodInfo.Name;
      PropertyName = propertyName ?? string.Empty;
      Details = details ?? [];
   }

   public string DeclaringType { get; init; } = string.Empty;
   public string MethodName { get; init; } = string.Empty;
   public string PropertyName { get; init; } = string.Empty;
   public IEnumerable<ErrorDetail> Details { get; init; } = [];


   #region Cumplimento de interfaz

   public CustomException() { }

   public CustomException(string message) : base(message) { }

   public CustomException(string message, Exception innerException) : base(message, innerException) { }

   #endregion

}

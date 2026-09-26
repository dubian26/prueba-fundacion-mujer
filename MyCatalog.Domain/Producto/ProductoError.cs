using MyCatalog.Base.Exceptions;
using System.Reflection;

namespace MyCatalog.Domain.Producto;

public static class ProductoError
{
   public static CustomException StockNoPuedeSerNegativo() =>
      new(
         methodInfo: MethodBase.GetCurrentMethod()!,
         message: "La operación no puede dejar el stock en negativo.");

   public static CustomException StockSuperaElMaximo() =>
      new(
         methodInfo: MethodBase.GetCurrentMethod()!,
         message: "El stock supera la cantidad máxima permitida.");

   public static CustomException NoHayStock() =>
      new(
         methodInfo: MethodBase.GetCurrentMethod()!,
         message: "No hay stock disponible");
}

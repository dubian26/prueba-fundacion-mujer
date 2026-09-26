using System.Reflection;
using MyCatalog.Base.Models;

namespace MyCatalog.Base.Exceptions;

public static class ExBase
{
   public static CustomException InfoNoValida(string message) =>
      new(
         methodInfo: MethodBase.GetCurrentMethod()!,
         message: message);

   public static CustomException ConexionNoValida() =>
      new(
         methodInfo: MethodBase.GetCurrentMethod()!,
         message: "No se ha configurado la cadena de conexión");

   public static CustomException NoExisteEnBD(string entidad, string id) =>
      new(
         methodInfo: MethodBase.GetCurrentMethod()!,
         message: $"{entidad} con id {id} no existe en la base de datos.");

   public static CustomException ExisteEnBD(string entidad, string id) =>
      new(
         methodInfo: MethodBase.GetCurrentMethod()!,
         message: $"{entidad} con id {id} ya existe en la base de datos.");

   public static CustomException ErrorDatosEntrada(
      string message, IEnumerable<ErrorDetail> details) =>
      new(
         methodInfo: MethodBase.GetCurrentMethod()!,
         message: message,
         details: details);
}

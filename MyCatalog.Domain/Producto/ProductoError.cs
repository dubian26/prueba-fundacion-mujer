using MyCatalog.Base.Exceptions;
using System.Reflection;

namespace MyCatalog.Domain.Producto;

public static class UsuarioError
{
    public static CustomException NoHayStock() =>
       new(
          methodInfo: MethodBase.GetCurrentMethod()!,
          message: "No hay stock disponible");
}
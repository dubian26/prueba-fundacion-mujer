using System.Globalization;

namespace MyCatalog.Base.Extensions;

public static class ObjectExtensions
{
   public static bool EsFecha(this object? obj)
   {
      if (obj is null) return false;

      Type tipo = obj.GetType();
      if (Nullable.GetUnderlyingType(tipo) is not null)
         tipo = Nullable.GetUnderlyingType(tipo)!;

      if (tipo == typeof(DateTime) ||
         tipo == typeof(DateOnly)) return true;

      if (obj is string dataFechaString)
      {
         if (DateTime.TryParse(
            dataFechaString,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out _)) return true;
      }

      return false;
   }
}

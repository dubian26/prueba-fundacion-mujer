using System.Linq.Expressions;
using System.Reflection;
using MyCatalog.Base.Exceptions;
using MyCatalog.Base.Extensions;
using MyCatalog.Base.Models;

namespace MyCatalog.Base.Configuration;

public abstract class Entidad<T>(string id) : Clonable where T : Entidad<T>
{
   public T EntidadEnBD { get; set; } = default!;
   public bool ExisteEnBD { get; set; } = false;
   public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
   public DateTime FechaModifica { get; set; } = DateTime.UtcNow;
   public IEnumerable<Item> Permisos { get; set; } = [];
   public IEnumerable<DataProp> DataProps { get; set; } = [];

   public void Respaldar() =>
      EntidadEnBD = (T)Clone();

   public void ValidarQueExistaEnBD()
   {
      if (ExisteEnBD) return;
      throw ExBase.NoExisteEnBD(typeof(T).Name, id);
   }

   public void ValidarQueNoExistaEnBD()
   {
      if (!ExisteEnBD) return;
      throw ExBase.ExisteEnBD(typeof(T).Name, id);
   }

   public IEnumerable<DataProp> DataPropsModificadas()
   {
      foreach (var prop in DataProps)
      {
         var propInfo = GetType().GetProperty(prop.Nombre);
         if (propInfo is null) continue;

         var valorPropClone = propInfo.GetValue(EntidadEnBD);
         var valor = propInfo.GetValue(this);

         prop.ValorActual = valorPropClone;
         prop.ValorNuevo = valor;
         prop.ValorActualCadena = ConvertirValorACadena(valorPropClone);
         prop.ValorNuevoCadena = ConvertirValorACadena(valor);
      }

      var propsModificadas = DataProps.Where(prop =>
         prop.ValorActualCadena != prop.ValorNuevoCadena);

      return propsModificadas;
   }

   public bool DataPropModificada<TProp>(Expression<Func<T, TProp>> expresion)
   {
      var propInfo = expresion.GetMember() as PropertyInfo;
      return DataPropsModificadas().Any(p => p.Nombre == propInfo?.Name);
   }

   private static string ConvertirValorACadena(object? value)
   {
      if (value is null)
         return string.Empty;

      if (value.EsFecha())
         return Convert.ToDateTime(value)
             .ToString("yyyy/MM/dd");

      Type type = value.GetType();
      if (Nullable.GetUnderlyingType(type) is not null)
         type = Nullable.GetUnderlyingType(type)!;

      if (type.IsEnum)
         return Convert.ToInt32(value).ToString();

      if (type == typeof(bool))
         return Convert.ToBoolean(value) ? "1" : "0";

      return value?.ToString() ?? string.Empty;
   }
}

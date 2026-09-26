using MyCatalog.Base.Interfaces;

namespace MyCatalog.Base.ValueObjects;

public class InfoUsuario : IInfoUsuario
{
   #region Propiedades

   public required string Email { get; set; }
   public required string Nombre { get; set; }
   public bool EsUsuarioApp { get; set; } = false;
   public string AppOrigen { get; set; } = "";
   public string ModuloOrigen { get; set; } = "";
   public string IPOrigen { get; set; } = "";
   public string Token { get; set; } = "";

   #endregion

   #region Metodos

   public static IInfoUsuario CrearDesdeDiccionario(
       Dictionary<string, string> claims)
   {
      return new InfoUsuario
      {
         Email = claims[nameof(Email)],
         Nombre = claims[nameof(Nombre)],
         EsUsuarioApp = claims[nameof(EsUsuarioApp)] == "S"
      };
   }

   public static IInfoUsuario CrearAnonimo()
   {
      return new InfoUsuario
      {
         Email = "sincorreo@sincorreo.com",
         Nombre = "Anonimo",
         EsUsuarioApp = false
      };
   }

   public void SetInstance(IInfoUsuario infoUsuario)
   {
      Email = infoUsuario.Email;
      Nombre = infoUsuario.Nombre;
      EsUsuarioApp = infoUsuario.EsUsuarioApp;
      AppOrigen = infoUsuario.AppOrigen;
      ModuloOrigen = infoUsuario.ModuloOrigen;
      IPOrigen = infoUsuario.IPOrigen;
      Token = infoUsuario.Token;
   }

   #endregion
}

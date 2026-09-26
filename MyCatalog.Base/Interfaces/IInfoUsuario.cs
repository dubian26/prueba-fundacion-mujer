namespace MyCatalog.Base.Interfaces;

public interface IInfoUsuario
{
   string Email { get; }
   string Nombre { get; }
   string AppOrigen { get; set; }
   string ModuloOrigen { get; set; }
   string IPOrigen { get; set; }
   string Token { get; set; }
   bool EsUsuarioApp { get; }

   void SetInstance(IInfoUsuario infoUsuario);
}

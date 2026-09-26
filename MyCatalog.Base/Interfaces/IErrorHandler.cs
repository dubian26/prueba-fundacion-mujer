using MyCatalog.Base.Models;

namespace MyCatalog.Base.Interfaces;

public interface IErrorHandler
{
   ErrorMessage Generar(Exception ex);
}

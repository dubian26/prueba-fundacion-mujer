using MyCatalog.Base.Configuration;

namespace MyCatalog.Domain.Producto;

public sealed class ProductoEntity : Entidad<ProductoEntity>
{
    private ProductoEntity(string id) : base(id)
    {
        Id = id;
        DataProps = [
            new() { Nombre = nameof(Nombre) },
            new() { Nombre = nameof(Descripcion) },
            new() { Nombre = nameof(Precio) },
            new() { Nombre = nameof(Stock) }
        ];
    }

    #region Propiedades

    public string Id { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public int Precio { get; set; }
    public int Stock { get; set; }

    #endregion

    #region ValidarQue

    public void ValidarQueStockNoSeaNegativo()
    {
        if (Stock < 0)
            throw ProductoError.StockNoPuedeSerNegativo();
    }

    #endregion

    #region Factory methods

    public static ProductoEntity MapearDesdeBD(ProductoRecord record)
    {
        var entidad = new ProductoEntity(record.Id)
        {
            ExisteEnBD = true,
            Nombre = record.Nombre,
            Descripcion = record.Descripcion,
            Precio = record.Precio,
            Stock = record.Stock,
            FechaCreacion = record.FechaCreacion,
            FechaModifica = record.FechaModifica
        };

        entidad.Respaldar();

        return entidad;
    }

    public static ProductoEntity NoExisteEnBD()
    {
        string id = Guid.CreateVersion7().ToString();

        var entidad = new ProductoEntity(id)
        {
            ExisteEnBD = false
        };

        entidad.Respaldar();

        return entidad;
    }

    #endregion
}

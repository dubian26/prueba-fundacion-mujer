namespace MyCatalog.Base.Configuration;

public abstract class Clonable : ICloneable
{
    public object Clone()
    {
        var type = GetType();
        var target = MemberwiseClone(); // Clone superficial

        type.GetProperties()
            .Where(prop =>
                prop.PropertyType != type &&
                prop.GetValue(this) is not null && !prop.PropertyType.IsValueType &&
                prop.PropertyType != typeof(string))
            .ToList()
            .ForEach(prop =>
            {
                if (prop.PropertyType.IsSubclassOf(typeof(Clonable)))
                {
                    // Objetos propios
                    var value = (Clonable)prop.GetValue(this)!;
                    prop.SetValue(target, value.Clone());
                }
                else if (prop.PropertyType.IsSubclassOf(typeof(Delegate)))
                {
                    // Manejar delegates
                    var value = (Delegate)prop.GetValue(this)!;
                    prop.SetValue(target, value.Clone());
                }
                else if (prop.PropertyType.IsSubclassOf(typeof(Array)))
                {
                    // Manejar arrays
                    var value = (Array)prop.GetValue(this)!;
                    prop.SetValue(target, value.Clone());
                }
            });

        return target;
    }
}

namespace SistemaInventario.Models;

// ProductoElectronico hereda de Productos (herencia)
// Tiene su propio atributo: MesesGarantia
public class ProductoElectronico : Productos
{
    public int MesesGarantia { get; set; }

    // el "base(...)" llama al constructor de la clase padre (Productos)
    public ProductoElectronico(int id, string nombre, int precio, int cantidad, int mesesGarantia)
        : base(id, nombre, "Electrónico", precio, cantidad)
    {
        MesesGarantia = mesesGarantia;
    }

    // override: sobrescribe el metodo de la clase padre (polimorfismo)
    public override string ObtenerInfo()
    {
        return $"Garantía: {MesesGarantia} meses";
    }

    public override string ToString()
    {
        // base.ToString() llama al ToString() de Productos, y le agrega la garantia
        return base.ToString() + $", Garantía: {MesesGarantia} meses";
    }
}

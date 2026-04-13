namespace SistemaInventario.Models;

// ProductoAlimenticio hereda de Productos (herencia)
// Tiene su propio atributo: FechaVencimiento
public class ProductoAlimenticio : Productos
{
    public string FechaVencimiento { get; set; }

    // el "base(...)" llama al constructor de la clase padre (Productos)
    public ProductoAlimenticio(int id, string nombre, int precio, int cantidad, string fechaVencimiento)
        : base(id, nombre, "Alimenticio", precio, cantidad)
    {
        FechaVencimiento = fechaVencimiento;
    }

    // override: sobrescribe el metodo de la clase padre (polimorfismo)
    public override string ObtenerInfo()
    {
        return $"Vence: {FechaVencimiento}";
    }

    public override string ToString()
    {
        // base.ToString() llama al ToString() de Productos, y le agrega la fecha de vencimiento
        return base.ToString() + $", Vence: {FechaVencimiento}";
    }
}

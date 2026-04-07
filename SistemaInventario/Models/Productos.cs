namespace SistemaInventario.Models;


// lo del autoincremento del id
// lo de la validaci[on de entradas
// filtrar busqueda por tipo
//guardar en un txt
// realiar venta
// crear subclases de productos (agrega herencia y polimorfismo) diferentes productos como producto electronico o alimenticio


public class Productos
{
    public int Id { get; set; }
    public string NombreProd { get; set; }
    public string TipoProd { get; set; }
    public int PrecioProd { get; set; }
    public int CantidadProd { get; set; }

    public Productos(int Id, string NombreProd, string TipoProd, int PrecioProd, int CantidadProd)
    {
        this.Id = Id;
        this.NombreProd = NombreProd;
        this.TipoProd = TipoProd;
        this.PrecioProd = PrecioProd;
        this.CantidadProd = CantidadProd;
    }


    public void ActualizarPrecio(int precio)
    {
        PrecioProd = precio;
    }
    public void AumentarStock(int aumento)
    {
        CantidadProd += aumento;
    }
    public void DisminuirStock(int disminucion)
    {
        CantidadProd -= disminucion;
    }
    public void HayStock()
    {
        if (CantidadProd > 0)
        {
            Console.WriteLine("Hay Stock");
        }
        else
        {
            Console.WriteLine("No hay stock");
        }
    }

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {NombreProd}, Tipo: {TipoProd}, Precio: {PrecioProd}, Cantidad: {CantidadProd}";
    }


}
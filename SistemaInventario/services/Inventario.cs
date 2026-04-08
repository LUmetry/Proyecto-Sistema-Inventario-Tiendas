using SistemaInventario.Models;
namespace SistemaInventario.services;

//tendre que añadir agregar prod, eliminar prod, actualizar prod, y mostrar prod. 
//tambien hacer algo para buscar por id

//Productos es la clase, productosList es la variable y producto es la variable temporal

public class Inventario
{
    private List<Productos> productosList;
    private int siguienteId = 1; // autoincremento: empieza en 1 y sube con cada producto

    public Inventario()
    {
        productosList = new List<Productos>(); //esto es para crear la lista dinamica que tendra los productos
    }

    public void AgregarProd(string nombre, string tipo, int precio, int cantidad) // ya no recibe id, lo asigna solo
    {
        Productos producto = new Productos(siguienteId, nombre, tipo, precio, cantidad);
        productosList.Add(producto);
        siguienteId++; // incrementa para el proximo producto
    }
    public void EliminarProd(Productos producto)
    {
        productosList.Remove(producto);
    }
    public void ActualizarProd(Productos producto)
    {
        productosList.Remove(producto);
        productosList.Add(producto);
    }
    public void MostrarProd()
    {
        foreach (var prod in productosList)
        {
            Console.WriteLine(prod.ToString());
        }
    }

    public void BuscarProd(int id)
    {
        foreach (var prod in productosList)
        {
            if (prod.Id == id)
            {
                Console.WriteLine(prod);
            }
        }
    }

}

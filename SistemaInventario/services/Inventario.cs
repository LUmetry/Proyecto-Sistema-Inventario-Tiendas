using SistemaInventario.Models;
namespace SistemaInventario.services;

//tendre que añadir agregar prod, eliminar prod, actualizar prod, y mostrar prod. 
//tambien hacer algo para buscar por id

//Productos es la clase, productosList es la variable y producto es la variable temporal

public class Inventario
{
    private List<Productos> productosList;

    public Inventario()
    {
        productosList = new List<Productos>(); //esto es para crear la lista dinamica que tendra los productos
    }

    public void AgregarProd(Productos producto) //de la clase Productos se va a agregar un producto a la lista
    {
        foreach (var prod in productosList)
        {
            if (prod.Id == producto.Id)
            {
                Console.WriteLine("El producto ya existe");
                return;
            }
        }
        productosList.Add(producto);
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

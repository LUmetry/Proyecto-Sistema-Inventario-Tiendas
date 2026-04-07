using SistemaInventario.services;
using SistemaInventario.Models;
namespace SistemaInventario;

class Program
{
    static void Main(string[] args)
    {
        Inventario inventario = new Inventario();
        int opcion = 0;
        do
        {
            Console.WriteLine("----- Sistema de Inventario -----\n");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar productos");
            Console.WriteLine("3. Actualizar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Buscar producto");
            Console.WriteLine("6. Salir");
            Console.Write("Ingrese una opcion: ");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el id: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el tipo: ");
                    string tipo = Console.ReadLine();
                    Console.Write("Ingrese el precio: ");
                    int precio = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la cantidad: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    inventario.AgregarProd(new Productos(id, nombre, tipo, precio, cantidad));
                    Console.WriteLine("Producto agregado correctamente\n");
                    break;

                case 2:
                    Console.WriteLine("----- Lista de Productos ----- \n");
                    inventario.MostrarProd();
                    break;

                case 3:
                    Console.WriteLine("----- Actualizar Producto ----- \n");
                    Console.Write("Ingrese el id: ");
                    int id2 = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nuevo precio: ");
                    int precio2 = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la nueva cantidad: ");
                    int cantidad2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                    inventario.ActualizarProd(new Productos(id2, "", "", precio2, cantidad2));
                    Console.WriteLine("Producto actualizado correctamente\n");
                    break;

                case 4:
                    Console.WriteLine("----- Eliminar Producto ----- \n");
                    Console.Write("Ingrese el id: ");
                    int id3 = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                    inventario.EliminarProd(new Productos(id3, "", "", 0, 0));
                    Console.WriteLine("Producto eliminado correctamente\n");
                    break;

                case 5:
                    Console.WriteLine("----- Buscar Producto ----- \n");
                    Console.Write("Ingrese el id: ");
                    int id4 = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                    inventario.BuscarProd(id4);
                    break;

                case 6:
                    Console.WriteLine("Chaíto :c \n");
                    break;

                default:
                    Console.WriteLine("No ves que es del 1 al 6? \n");
                    break;
            }
        } while (opcion != 6);
    }
}

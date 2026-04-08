using SistemaInventario.services;
using SistemaInventario.Models;
namespace SistemaInventario;

class Program
{
    // metodo helper: le pregunta al usuario un numero y lo valida.
    // si escribe algo que no es numero, avisa y devuelve false.
    static bool LeerEntero(string mensaje, out int resultado)
    {
        Console.Write(mensaje);
        if (!int.TryParse(Console.ReadLine(), out resultado))
        {
            Console.WriteLine("Error: eso no es un número válido.\n");
            return false;
        }
        return true;
    }

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

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Error: ingresa un número del 1 al 6.\n");
                continue; // vuelve al inicio del do-while
            }

            Console.WriteLine("\n");
            switch (opcion)
            {
                case 1:
                    // ya no se pide el id, el sistema lo asigna solo
                    Console.Write("Ingrese el nombre: ");
                    string nombre = Console.ReadLine() ?? "";
                    Console.Write("Ingrese el tipo: ");
                    string tipo = Console.ReadLine() ?? "";

                    if (!LeerEntero("Ingrese el precio: ", out int precio)) break;
                    if (!LeerEntero("Ingrese la cantidad: ", out int cantidad)) break;

                    inventario.AgregarProd(nombre, tipo, precio, cantidad);
                    Console.WriteLine("Producto agregado correctamente\n");
                    break;

                case 2:
                    Console.WriteLine("----- Lista de Productos ----- \n");
                    inventario.MostrarProd();
                    break;

                case 3:
                    Console.WriteLine("----- Actualizar Producto ----- \n");
                    if (!LeerEntero("Ingrese el id: ", out int id2)) break;
                    if (!LeerEntero("Ingrese el nuevo precio: ", out int precio2)) break;
                    if (!LeerEntero("Ingrese la nueva cantidad: ", out int cantidad2)) break;

                    Console.WriteLine("\n");
                    inventario.ActualizarProd(new Productos(id2, "", "", precio2, cantidad2));
                    Console.WriteLine("Producto actualizado correctamente\n");
                    break;

                case 4:
                    Console.WriteLine("----- Eliminar Producto ----- \n");
                    if (!LeerEntero("Ingrese el id: ", out int id3)) break;

                    Console.WriteLine("\n");
                    inventario.EliminarProd(new Productos(id3, "", "", 0, 0));
                    Console.WriteLine("Producto eliminado correctamente\n");
                    break;

                case 5:
                    Console.WriteLine("----- Buscar Producto ----- \n");
                    if (!LeerEntero("Ingrese el id: ", out int id4)) break;

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

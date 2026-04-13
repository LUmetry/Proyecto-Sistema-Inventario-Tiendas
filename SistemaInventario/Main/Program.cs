using SistemaInventario.services;
using SistemaInventario.Models;
namespace SistemaInventario;

class Program
{

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

    // ruta del archivo donde se guarda el inventario (se crea junto al ejecutable)
    const string ARCHIVO = "inventario.txt";

    static void Main(string[] args)
    {
        Inventario inventario = new Inventario();
        inventario.CargarDesdeTxt(ARCHIVO); // carga datos guardados al iniciar
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
                    // primero preguntamos el tipo de producto
                    Console.WriteLine("¿Qué tipo de producto desea agregar?");
                    Console.WriteLine("  1. Electrónico");
                    Console.WriteLine("  2. Alimenticio");
                    if (!LeerEntero("Tipo: ", out int tipoProd)) break;

                    Console.Write("Ingrese el nombre: ");
                    string nombre = Console.ReadLine() ?? "";
                    if (!LeerEntero("Ingrese el precio: ", out int precio)) break;
                    if (!LeerEntero("Ingrese la cantidad: ", out int cantidad)) break;

                    if (tipoProd == 1)
                    {

                        if (!LeerEntero("Meses de garantía: ", out int garantia)) break;
                        inventario.AgregarProd(new ProductoElectronico(0, nombre, precio, cantidad, garantia));
                    }
                    else if (tipoProd == 2)
                    {

                        Console.Write("Fecha de vencimiento (ej: 31/12/2025): ");
                        string fechaVenc = Console.ReadLine() ?? "";
                        inventario.AgregarProd(new ProductoAlimenticio(0, nombre, precio, cantidad, fechaVenc));
                    }
                    else
                    {
                        Console.WriteLine("Tipo no válido.\n");
                        break;
                    }

                    Console.WriteLine("Producto agregado correctamente\n");
                    break;

                case 2:
                    Console.WriteLine("----- Mostrar Productos -----\n");
                    Console.WriteLine("  1. Todos");
                    Console.WriteLine("  2. Solo Electrónicos");
                    Console.WriteLine("  3. Solo Alimenticios");
                    if (!LeerEntero("Filtro: ", out int filtro)) break;

                    Console.WriteLine();
                    if (filtro == 1)
                        inventario.MostrarProd();
                    else if (filtro == 2)
                        inventario.MostrarProdPorTipo("Electrónico");
                    else if (filtro == 3)
                        inventario.MostrarProdPorTipo("Alimenticio");
                    else
                        Console.WriteLine("Opción no válida.\n");
                    break;

                case 3:
                    Console.WriteLine("----- Actualizar Producto ----- \n");
                    if (!LeerEntero("Ingrese el id: ", out int id2)) break;
                    if (!LeerEntero("Ingrese el nuevo precio: ", out int precio2)) break;
                    if (!LeerEntero("Ingrese la nueva cantidad: ", out int cantidad2)) break;

                    Console.WriteLine("\n");
                    inventario.ActualizarProd(id2, precio2, cantidad2);
                    Console.WriteLine("Producto actualizado correctamente\n");
                    break;

                case 4:
                    Console.WriteLine("----- Eliminar Producto ----- \n");
                    if (!LeerEntero("Ingrese el id: ", out int id3)) break;

                    Console.WriteLine("\n");
                    inventario.EliminarProd(id3);
                    Console.WriteLine("Producto eliminado correctamente\n");
                    break;

                case 5:
                    Console.WriteLine("----- Buscar Producto ----- \n");
                    if (!LeerEntero("Ingrese el id: ", out int id4)) break;

                    Console.WriteLine("\n");
                    inventario.BuscarProd(id4);
                    break;

                case 6:
                    inventario.GuardarEnTxt(ARCHIVO); // guarda antes de salir
                    Console.WriteLine("Chaíto :c \n");
                    break;

                default:
                    Console.WriteLine("No ves que es del 1 al 6? \n");
                    break;
            }
        } while (opcion != 6);
    }
}

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

    // recibe cualquier Productos o subclase suya (ProductoElectronico, ProductoAlimenticio, etc.)
    public void AgregarProd(Productos producto)
    {
        producto.Id = siguienteId; // asigna el id automaticamente
        productosList.Add(producto);
        siguienteId++; // incrementa para el proximo producto
    }
    public void EliminarProd(int id)
    {
        // buscamos el producto real por su ID
        Productos? encontrado = null;
        foreach (var prod in productosList)
        {
            if (prod.Id == id)
            {
                encontrado = prod;
                break;
            }
        }

        if (encontrado != null)
            productosList.Remove(encontrado);
        else
            Console.WriteLine("No se encontró un producto con ese ID.\n");
    }

    // actualiza precio y cantidad del producto que tenga ese ID
    public void ActualizarProd(int id, int nuevoPrecio, int nuevaCantidad)
    {
        foreach (var prod in productosList)
        {
            if (prod.Id == id)
            {
                prod.PrecioProd = nuevoPrecio;
                prod.CantidadProd = nuevaCantidad;
                return;
            }
        }
        Console.WriteLine("No se encontró un producto con ese ID.\n");
    }
    public void MostrarProd()
    {
        foreach (var prod in productosList)
        {
            Console.WriteLine(prod.ToString());
        }
    }

    // muestra solo los productos cuyo TipoProd coincida (ej: "Electrónico", "Alimenticio")
    public void MostrarProdPorTipo(string tipo)
    {
        bool hayResultados = false;
        foreach (var prod in productosList)
        {
            if (prod.TipoProd.Equals(tipo, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(prod.ToString());
                hayResultados = true;
            }
        }
        if (!hayResultados)
            Console.WriteLine($"No hay productos de tipo '{tipo}' en el inventario.\n");
    }

    public void BuscarProd(int id)
    {
        foreach (var prod in productosList)
        {
            if (prod.Id == id)
            {
                Console.WriteLine($"{prod}\n");
            }
        }
    }

    // --- PERSISTENCIA EN ARCHIVO ---

    // Guarda todos los productos en un archivo .txt, una línea por producto.
    // Formato: Tipo|Id|Nombre|Precio|Cantidad|DatoExtra
    public void GuardarEnTxt(string ruta)
    {
        // StreamWriter crea (o sobreescribe) el archivo en la ruta indicada
        using StreamWriter escritor = new StreamWriter(ruta);

        foreach (var prod in productosList)
        {
            // "is" comprueba si el objeto es de esa subclase concreta
            if (prod is ProductoElectronico pe)
                escritor.WriteLine($"Electronico|{pe.Id}|{pe.NombreProd}|{pe.PrecioProd}|{pe.CantidadProd}|{pe.MesesGarantia}");
            else if (prod is ProductoAlimenticio pa)
                escritor.WriteLine($"Alimenticio|{pa.Id}|{pa.NombreProd}|{pa.PrecioProd}|{pa.CantidadProd}|{pa.FechaVencimiento}");
        }

        Console.WriteLine($"Inventario guardado en '{ruta}'.\n");
    }

    // Lee el archivo .txt y reconstruye la lista de productos en memoria.
    public void CargarDesdeTxt(string ruta)
    {
        // Si el archivo no existe todavía, no hacemos nada (primera ejecución)
        if (!File.Exists(ruta)) return;

        string[] lineas = File.ReadAllLines(ruta);

        foreach (string linea in lineas)
        {
            // Separamos cada campo usando el caracter '|'
            string[] partes = linea.Split('|');
            if (partes.Length < 6) continue; // línea inválida, la saltamos

            string tipo = partes[0];
            int id = int.Parse(partes[1]);
            string nombre = partes[2];
            int precio = int.Parse(partes[3]);
            int cantidad = int.Parse(partes[4]);
            string datoExtra = partes[5];

            Productos prod;
            if (tipo == "Electronico")
            {
                int meses = int.Parse(datoExtra);
                prod = new ProductoElectronico(id, nombre, precio, cantidad, meses);
            }
            else if (tipo == "Alimenticio")
            {
                prod = new ProductoAlimenticio(id, nombre, precio, cantidad, datoExtra);
            }
            else continue; // tipo desconocido, lo saltamos

            // Restauramos el ID original (no usamos AgregarProd para no sobreescribirlo)
            prod.Id = id;
            productosList.Add(prod);

            // Actualizamos el contador para que el próximo ID nuevo sea mayor al máximo cargado
            if (id >= siguienteId)
                siguienteId = id + 1;
        }

        Console.WriteLine($"Inventario cargado desde '{ruta}' ({lineas.Length} productos).\n");
    }

}

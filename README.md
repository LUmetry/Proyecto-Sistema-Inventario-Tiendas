# 🏪 Sistema de Inventario de Tiendas — C#

## Estado actual del proyecto

Esta es una versión **actualizada y presentable** del sistema de inventario desarrollado en C# como aplicación de consola, con mejoras aplicadas respecto a la entrega anterior.

El sistema actualmente permite:

- Agregar productos (con validación de ID duplicado)
- Mostrar todos los productos en inventario
- Actualizar precio y cantidad de un producto
- Eliminar un producto por ID
- Buscar un producto por ID
- Menú de navegación en consola

## Estructura del proyecto

```
SistemaInventario/
├── Main/
│   └── Program.cs          # Punto de entrada y menú principal
├── Models/
│   └── Productos.cs        # Clase que representa un producto
└── services/
    └── Inventario.cs       # Lógica de gestión del inventario (agregar, eliminar, etc.)
```

## Mejoras implementadas

1.  **Autoincremento de ID** — El sistema asigna el ID automáticamente. El usuario ya no lo ingresa manualmente, eliminando el riesgo de IDs repetidos.

2.  **Validación de entradas** — Se agregó un método `LeerEntero()` que valida todos los inputs numéricos con `int.TryParse`. Si el usuario escribe algo inválido, el programa avisa y no crashea.

## Mejoras planificadas para la presentación final

Las siguientes funcionalidades serán implementadas antes de la entrega final:

1. **Filtrar búsqueda por tipo** — Se podrá listar solo los productos de una categoría específica (ej: electrónica, alimentos).

2. **Guardar en archivo .txt** — El inventario se guardará en un archivo de texto al cerrar el programa y se cargará automáticamente al iniciar, para que los datos no se pierdan.

3. **Realizar ventas** — Se podrá registrar una venta, descontando el stock del producto correspondiente y calculando el total.

4. **Subclases de Productos** — Se crearán subclases como `ProductoElectronico` y `ProductoAlimenticio` con atributos propios, incorporando los pilares de **herencia** y **polimorfismo** de la Programación Orientada a Objetos.

---

> Desarrollado con C# (.NET) — Programación 1

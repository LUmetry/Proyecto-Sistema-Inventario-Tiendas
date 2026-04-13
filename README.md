#  Sistema de Inventario de Tiendas — C#

## Estado del proyecto — Entrega final

Este es el sistema de inventario desarrollado en C# como aplicación de consola para la materia Programación 1.

El sistema permite:

- Agregar productos (electrónicos o alimenticios)
- Mostrar todos los productos o filtrar por tipo
- Actualizar precio y cantidad de un producto por ID
- Eliminar un producto por ID
- Buscar un producto por ID
- Guardar el inventario en un archivo `.txt` al salir y cargarlo automáticamente al iniciar

## Estructura del proyecto

```
SistemaInventario/
├── Main/
│   └── Program.cs               # Punto de entrada y menú principal
├── Models/
│   ├── Productos.cs             # Clase base de producto
│   ├── ProductoElectronico.cs   # Subclase con garantía (herencia + polimorfismo)
│   └── ProductoAlimenticio.cs   # Subclase con fecha de vencimiento (herencia + polimorfismo)
└── services/
    └── Inventario.cs            # Lógica de gestión: agregar, eliminar, actualizar, buscar, guardar/cargar
```

## Funcionalidades implementadas

1. **Autoincremento de ID** — El sistema asigna el ID automáticamente, sin riesgo de duplicados.

2. **Validación de entradas** — El método `LeerEntero()` valida todos los inputs numéricos con `int.TryParse`. Si el usuario escribe algo inválido, el programa avisa y no crashea.

3. **Filtrar por tipo** — Al mostrar productos, el usuario puede elegir ver todos, solo electrónicos o solo alimenticios.

4. **Persistencia en archivo `.txt`** — Al cerrar el programa se guarda el inventario en `inventario.txt`. Al volver a abrirlo, los datos se cargan automáticamente.

5. **Herencia y polimorfismo** — `ProductoElectronico` y `ProductoAlimenticio` heredan de `Productos` y sobreescriben `ObtenerInfo()` y `ToString()` con su información propia.

## Funcionalidad no implementada

- **Realizar ventas** — Esta función (descontar stock y calcular el total de una venta) no forma parte de la entrega final.

---

> Desarrollado con C# (.NET) — Programación 1

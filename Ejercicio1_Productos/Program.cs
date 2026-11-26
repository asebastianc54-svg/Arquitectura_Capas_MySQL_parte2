using Ejercicio1_Productos.Negocio;

ProductoNegocio negocio = new ProductoNegocio();
bool salir = false;

while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("--- Gestión de Productos por DNI ---");
    Console.WriteLine("1. Buscar por DNI");
    Console.WriteLine("2. Agregar producto");
    Console.WriteLine("3. Modificar producto");
    Console.WriteLine("4. Eliminar producto");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Ingrese DNI: ");
            string? dniBuscar = Console.ReadLine();
            Producto? encontrado = negocio.ConsultarPorDni(dniBuscar);
            if (encontrado != null)
            {
                Console.WriteLine($"DNI: {encontrado.Dni} | Código: {encontrado.Codigo} | Nombre: {encontrado.Nombre} | Precio: ${encontrado.Precio:F2}");
            }
            else
            {
                Console.WriteLine("No se encontró un producto con ese DNI.");
            }
            break;

        case "2":
            Console.Write("Ingrese DNI: ");
            string dniNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese Código (ej: PROD-104): ");
            string codigoNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese Nombre: ");
            string nombreNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese Precio: ");
            decimal.TryParse(Console.ReadLine(), out decimal precioNuevo);

            Producto nuevoProducto = new Producto(dniNuevo, codigoNuevo, nombreNuevo, precioNuevo);
            bool agregado = negocio.AgregarProducto(nuevoProducto);
            Console.WriteLine(agregado ? "Producto agregado correctamente." : "No se pudo agregar el producto.");
            break;

        case "3":
            Console.Write("Ingrese DNI del producto a modificar: ");
            string dniMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nuevo Código (ej: PROD-104): ");
            string codigoMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nuevo Nombre: ");
            string nombreMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nuevo Precio: ");
            decimal.TryParse(Console.ReadLine(), out decimal precioMod);

            Producto productoMod = new Producto(dniMod, codigoMod, nombreMod, precioMod);
            bool modificado = negocio.ModificarProducto(productoMod);
            Console.WriteLine(modificado ? "Producto modificado correctamente." : "No se pudo modificar el producto.");
            break;

        case "4":
            Console.Write("Ingrese DNI del producto a eliminar: ");
            string? dniElim = Console.ReadLine();
            bool eliminado = negocio.EliminarProducto(dniElim);
            Console.WriteLine(eliminado ? "Producto eliminado correctamente." : "No se pudo eliminar el producto.");
            break;

        case "5":
            salir = true;
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}

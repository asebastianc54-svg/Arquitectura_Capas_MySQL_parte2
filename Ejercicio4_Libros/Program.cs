using Ejercicio4_Libros.Negocio;

LibroNegocio negocio = new LibroNegocio();
bool salir = false;

while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("--- Gestión de Libros por DNI ---");
    Console.WriteLine("1. Buscar por DNI");
    Console.WriteLine("2. Agregar libro");
    Console.WriteLine("3. Modificar libro");
    Console.WriteLine("4. Eliminar libro");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Ingrese DNI: ");
            string? dniBuscar = Console.ReadLine();
            Libro? encontrado = negocio.ConsultarPorDni(dniBuscar);
            if (encontrado != null)
            {
                string estadoTexto = encontrado.Disponible ? "Disponible" : "Prestado";
                Console.WriteLine($"DNI: {encontrado.Dni} | ISBN: {encontrado.Isbn} | Título: {encontrado.Titulo} | Autor: {encontrado.Autor} | Estado: {estadoTexto}");
            }
            else
            {
                Console.WriteLine("No se encontró un libro con ese DNI.");
            }
            break;

        case "2":
            Console.Write("Ingrese DNI: ");
            string dniNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese ISBN: ");
            string isbnNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese Título: ");
            string tituloNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese Autor: ");
            string autorNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("¿Está disponible? (s/n): ");
            bool disponibleNuevo = (Console.ReadLine() ?? string.Empty).Trim().Equals("s", StringComparison.OrdinalIgnoreCase);

            Libro nuevoLibro = new Libro(dniNuevo, isbnNuevo, tituloNuevo, autorNuevo, disponibleNuevo);
            bool agregado = negocio.AgregarLibro(nuevoLibro);
            Console.WriteLine(agregado ? "Libro agregado correctamente." : "No se pudo agregar el libro.");
            break;

        case "3":
            Console.Write("Ingrese DNI del libro a modificar: ");
            string dniMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nuevo ISBN: ");
            string isbnMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nuevo Título: ");
            string tituloMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nuevo Autor: ");
            string autorMod = Console.ReadLine() ?? string.Empty;
            Console.Write("¿Está disponible? (s/n): ");
            bool disponibleMod = (Console.ReadLine() ?? string.Empty).Trim().Equals("s", StringComparison.OrdinalIgnoreCase);

            Libro libroMod = new Libro(dniMod, isbnMod, tituloMod, autorMod, disponibleMod);
            bool modificado = negocio.ModificarLibro(libroMod);
            Console.WriteLine(modificado ? "Libro modificado correctamente." : "No se pudo modificar el libro.");
            break;

        case "4":
            Console.Write("Ingrese DNI del libro a eliminar: ");
            string? dniElim = Console.ReadLine();
            bool eliminado = negocio.EliminarLibro(dniElim);
            Console.WriteLine(eliminado ? "Libro eliminado correctamente." : "No se pudo eliminar el libro.");
            break;

        case "5":
            salir = true;
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}

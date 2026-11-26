using Ejercicio2_Alumnos.Negocio;

AlumnoNegocio negocio = new AlumnoNegocio();
bool salir = false;

while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("--- Gestión de Alumnos por DNI ---");
    Console.WriteLine("1. Buscar por DNI");
    Console.WriteLine("2. Agregar alumno");
    Console.WriteLine("3. Modificar alumno");
    Console.WriteLine("4. Eliminar alumno");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Ingrese DNI: ");
            string? dniBuscar = Console.ReadLine();
            Alumno? encontrado = negocio.ConsultarPorDni(dniBuscar);
            if (encontrado != null)
            {
                Console.WriteLine($"DNI: {encontrado.Dni} | Legajo: {encontrado.Legajo} | Nombre: {encontrado.Nombre} | Condición: {encontrado.Condicion}");
            }
            else
            {
                Console.WriteLine("No se encontró un alumno con ese DNI.");
            }
            break;

        case "2":
            Console.Write("Ingrese DNI: ");
            string dniNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese Legajo: ");
            int.TryParse(Console.ReadLine(), out int legajoNuevo);
            Console.Write("Ingrese Nombre: ");
            string nombreNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese Condición: ");
            string condicionNuevo = Console.ReadLine() ?? string.Empty;

            Alumno nuevoAlumno = new Alumno(dniNuevo, legajoNuevo, nombreNuevo, condicionNuevo);
            bool agregado = negocio.AgregarAlumno(nuevoAlumno);
            Console.WriteLine(agregado ? "Alumno agregado correctamente." : "No se pudo agregar el alumno.");
            break;

        case "3":
            Console.Write("Ingrese DNI del alumno a modificar: ");
            string dniMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nuevo Legajo: ");
            int.TryParse(Console.ReadLine(), out int legajoMod);
            Console.Write("Ingrese nuevo Nombre: ");
            string nombreMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nueva Condición: ");
            string condicionMod = Console.ReadLine() ?? string.Empty;

            Alumno alumnoMod = new Alumno(dniMod, legajoMod, nombreMod, condicionMod);
            bool modificado = negocio.ModificarAlumno(alumnoMod);
            Console.WriteLine(modificado ? "Alumno modificado correctamente." : "No se pudo modificar el alumno.");
            break;

        case "4":
            Console.Write("Ingrese DNI del alumno a eliminar: ");
            string? dniElim = Console.ReadLine();
            bool eliminado = negocio.EliminarAlumno(dniElim);
            Console.WriteLine(eliminado ? "Alumno eliminado correctamente." : "No se pudo eliminar el alumno.");
            break;

        case "5":
            salir = true;
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}

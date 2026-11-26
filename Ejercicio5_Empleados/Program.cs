using Ejercicio5_Empleados.Negocio;

EmpleadoNegocio negocio = new EmpleadoNegocio();
bool salir = false;

while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("--- Gestión de Empleados por DNI ---");
    Console.WriteLine("1. Buscar por DNI");
    Console.WriteLine("2. Agregar empleado");
    Console.WriteLine("3. Modificar empleado");
    Console.WriteLine("4. Eliminar empleado");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Ingrese DNI: ");
            string? dniBuscar = Console.ReadLine();
            Empleado? encontrado = negocio.ConsultarPorDni(dniBuscar);
            if (encontrado != null)
            {
                Console.WriteLine($"DNI: {encontrado.Dni} | ID: {encontrado.Id} | Nombre: {encontrado.Nombre} | Puesto: {encontrado.Puesto} | Departamento: {encontrado.Departamento}");
            }
            else
            {
                Console.WriteLine("No se encontró un empleado con ese DNI.");
            }
            break;

        case "2":
            Console.Write("Ingrese DNI: ");
            string dniNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese ID (100 a 999): ");
            int.TryParse(Console.ReadLine(), out int idNuevo);
            Console.Write("Ingrese Nombre completo: ");
            string nombreNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese Puesto: ");
            string puestoNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese Departamento: ");
            string departamentoNuevo = Console.ReadLine() ?? string.Empty;

            Empleado nuevoEmpleado = new Empleado(dniNuevo, idNuevo, nombreNuevo, puestoNuevo, departamentoNuevo);
            bool agregado = negocio.AgregarEmpleado(nuevoEmpleado);
            Console.WriteLine(agregado ? "Empleado agregado correctamente." : "No se pudo agregar el empleado.");
            break;

        case "3":
            Console.Write("Ingrese DNI del empleado a modificar: ");
            string dniMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nuevo ID (100 a 999): ");
            int.TryParse(Console.ReadLine(), out int idMod);
            Console.Write("Ingrese nuevo Nombre completo: ");
            string nombreMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nuevo Puesto: ");
            string puestoMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nuevo Departamento: ");
            string departamentoMod = Console.ReadLine() ?? string.Empty;

            Empleado empleadoMod = new Empleado(dniMod, idMod, nombreMod, puestoMod, departamentoMod);
            bool modificado = negocio.ModificarEmpleado(empleadoMod);
            Console.WriteLine(modificado ? "Empleado modificado correctamente." : "No se pudo modificar el empleado.");
            break;

        case "4":
            Console.Write("Ingrese DNI del empleado a eliminar: ");
            string? dniElim = Console.ReadLine();
            bool eliminado = negocio.EliminarEmpleado(dniElim);
            Console.WriteLine(eliminado ? "Empleado eliminado correctamente." : "No se pudo eliminar el empleado.");
            break;

        case "5":
            salir = true;
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}

using Ejercicio3_Vehiculos.Negocio;

VehiculoNegocio negocio = new VehiculoNegocio();
bool salir = false;

while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("--- Gestión de Vehículos por DNI ---");
    Console.WriteLine("1. Buscar por DNI");
    Console.WriteLine("2. Agregar vehículo");
    Console.WriteLine("3. Modificar vehículo");
    Console.WriteLine("4. Eliminar vehículo");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Ingrese DNI: ");
            string? dniBuscar = Console.ReadLine();
            Vehiculo? encontrado = negocio.ConsultarPorDni(dniBuscar);
            if (encontrado != null)
            {
                string deudaTexto = encontrado.TieneDeuda ? "Posee deudas pendientes" : "Sin deudas pendientes";
                Console.WriteLine($"DNI: {encontrado.Dni} | Patente: {encontrado.Patente} | Modelo: {encontrado.Modelo} | Estado: {deudaTexto}");
            }
            else
            {
                Console.WriteLine("No se encontró un vehículo con ese DNI.");
            }
            break;

        case "2":
            Console.Write("Ingrese DNI: ");
            string dniNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese Patente (mínimo 6 caracteres): ");
            string patenteNueva = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese Modelo: ");
            string modeloNuevo = Console.ReadLine() ?? string.Empty;
            Console.Write("¿Tiene deuda? (s/n): ");
            bool deudaNueva = (Console.ReadLine() ?? string.Empty).Trim().Equals("s", StringComparison.OrdinalIgnoreCase);

            Vehiculo nuevoVehiculo = new Vehiculo(dniNuevo, patenteNueva, modeloNuevo, deudaNueva);
            bool agregado = negocio.AgregarVehiculo(nuevoVehiculo);
            Console.WriteLine(agregado ? "Vehículo agregado correctamente." : "No se pudo agregar el vehículo.");
            break;

        case "3":
            Console.Write("Ingrese DNI del vehículo a modificar: ");
            string dniMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nueva Patente (mínimo 6 caracteres): ");
            string patenteMod = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese nuevo Modelo: ");
            string modeloMod = Console.ReadLine() ?? string.Empty;
            Console.Write("¿Tiene deuda? (s/n): ");
            bool deudaMod = (Console.ReadLine() ?? string.Empty).Trim().Equals("s", StringComparison.OrdinalIgnoreCase);

            Vehiculo vehiculoMod = new Vehiculo(dniMod, patenteMod, modeloMod, deudaMod);
            bool modificado = negocio.ModificarVehiculo(vehiculoMod);
            Console.WriteLine(modificado ? "Vehículo modificado correctamente." : "No se pudo modificar el vehículo.");
            break;

        case "4":
            Console.Write("Ingrese DNI del vehículo a eliminar: ");
            string? dniElim = Console.ReadLine();
            bool eliminado = negocio.EliminarVehiculo(dniElim);
            Console.WriteLine(eliminado ? "Vehículo eliminado correctamente." : "No se pudo eliminar el vehículo.");
            break;

        case "5":
            salir = true;
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}

using Ejercicio3_Vehiculos.Datos;

namespace Ejercicio3_Vehiculos.Negocio
{
    public class VehiculoNegocio
    {
        private readonly VehiculoDatos _datos = new VehiculoDatos();

        public Vehiculo? ConsultarPorDni(string? dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                return null;
            }

            var registro = _datos.BuscarPorDni(dni.Trim());
            if (registro == null)
            {
                return null;
            }

            return new Vehiculo(registro.Value.Dni, registro.Value.Patente, registro.Value.Modelo, registro.Value.TieneDeuda);
        }

        public bool AgregarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null) return false;
            if (string.IsNullOrWhiteSpace(vehiculo.Dni) ||
                string.IsNullOrWhiteSpace(vehiculo.Patente) ||
                string.IsNullOrWhiteSpace(vehiculo.Modelo))
            {
                return false;
            }

            string patenteLimpia = vehiculo.Patente.Trim();
            if (patenteLimpia.Length < 6)
            {
                return false;
            }

            if (_datos.BuscarPorDni(vehiculo.Dni.Trim()) != null)
            {
                return false;
            }

            return _datos.Agregar(vehiculo.Dni.Trim(), patenteLimpia, vehiculo.Modelo.Trim(), vehiculo.TieneDeuda);
        }

        public bool ModificarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null) return false;
            if (string.IsNullOrWhiteSpace(vehiculo.Dni) ||
                string.IsNullOrWhiteSpace(vehiculo.Patente) ||
                string.IsNullOrWhiteSpace(vehiculo.Modelo))
            {
                return false;
            }

            string patenteLimpia = vehiculo.Patente.Trim();
            if (patenteLimpia.Length < 6)
            {
                return false;
            }

            return _datos.Modificar(vehiculo.Dni.Trim(), patenteLimpia, vehiculo.Modelo.Trim(), vehiculo.TieneDeuda);
        }

        public bool EliminarVehiculo(string? dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return false;
            return _datos.Eliminar(dni.Trim());
        }
    }
}

using Ejercicio5_Empleados.Datos;

namespace Ejercicio5_Empleados.Negocio
{
    public class EmpleadoNegocio
    {
        private readonly EmpleadoDatos _datos = new EmpleadoDatos();

        public Empleado? ConsultarPorDni(string? dni)
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

            return new Empleado(registro.Value.Dni, registro.Value.Id, registro.Value.Nombre, registro.Value.Puesto, registro.Value.Departamento);
        }

        public bool AgregarEmpleado(Empleado empleado)
        {
            if (empleado == null) return false;
            if (string.IsNullOrWhiteSpace(empleado.Dni) ||
                empleado.Id < 100 || empleado.Id > 999 ||
                string.IsNullOrWhiteSpace(empleado.Nombre) ||
                string.IsNullOrWhiteSpace(empleado.Puesto) ||
                string.IsNullOrWhiteSpace(empleado.Departamento))
            {
                return false;
            }

            if (_datos.BuscarPorDni(empleado.Dni.Trim()) != null)
            {
                return false;
            }

            return _datos.Agregar(empleado.Dni.Trim(), empleado.Id, empleado.Nombre.Trim(), empleado.Puesto.Trim(), empleado.Departamento.Trim());
        }

        public bool ModificarEmpleado(Empleado empleado)
        {
            if (empleado == null) return false;
            if (string.IsNullOrWhiteSpace(empleado.Dni) ||
                empleado.Id < 100 || empleado.Id > 999 ||
                string.IsNullOrWhiteSpace(empleado.Nombre) ||
                string.IsNullOrWhiteSpace(empleado.Puesto) ||
                string.IsNullOrWhiteSpace(empleado.Departamento))
            {
                return false;
            }

            return _datos.Modificar(empleado.Dni.Trim(), empleado.Id, empleado.Nombre.Trim(), empleado.Puesto.Trim(), empleado.Departamento.Trim());
        }

        public bool EliminarEmpleado(string? dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return false;
            return _datos.Eliminar(dni.Trim());
        }
    }
}

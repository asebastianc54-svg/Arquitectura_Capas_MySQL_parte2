using Ejercicio2_Alumnos.Datos;

namespace Ejercicio2_Alumnos.Negocio
{
    public class AlumnoNegocio
    {
        private readonly AlumnoDatos _datos = new AlumnoDatos();

        public Alumno? ConsultarPorDni(string? dni)
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

            return new Alumno(registro.Value.Dni, registro.Value.Legajo, registro.Value.Nombre, registro.Value.Condicion);
        }

        public bool AgregarAlumno(Alumno alumno)
        {
            if (alumno == null) return false;
            if (string.IsNullOrWhiteSpace(alumno.Dni) ||
                alumno.Legajo <= 0 ||
                string.IsNullOrWhiteSpace(alumno.Nombre) ||
                string.IsNullOrWhiteSpace(alumno.Condicion))
            {
                return false;
            }

            if (_datos.BuscarPorDni(alumno.Dni.Trim()) != null)
            {
                return false;
            }

            return _datos.Agregar(alumno.Dni.Trim(), alumno.Legajo, alumno.Nombre.Trim(), alumno.Condicion.Trim());
        }

        public bool ModificarAlumno(Alumno alumno)
        {
            if (alumno == null) return false;
            if (string.IsNullOrWhiteSpace(alumno.Dni) ||
                alumno.Legajo <= 0 ||
                string.IsNullOrWhiteSpace(alumno.Nombre) ||
                string.IsNullOrWhiteSpace(alumno.Condicion))
            {
                return false;
            }

            return _datos.Modificar(alumno.Dni.Trim(), alumno.Legajo, alumno.Nombre.Trim(), alumno.Condicion.Trim());
        }

        public bool EliminarAlumno(string? dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return false;
            return _datos.Eliminar(dni.Trim());
        }
    }
}

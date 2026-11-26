using Ejercicio4_Libros.Datos;

namespace Ejercicio4_Libros.Negocio
{
    public class LibroNegocio
    {
        private readonly LibroDatos _datos = new LibroDatos();

        public Libro? ConsultarPorDni(string? dni)
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

            return new Libro(registro.Value.Dni, registro.Value.Isbn, registro.Value.Titulo, registro.Value.Autor, registro.Value.Disponible);
        }

        public bool AgregarLibro(Libro libro)
        {
            if (libro == null) return false;
            if (string.IsNullOrWhiteSpace(libro.Dni) ||
                string.IsNullOrWhiteSpace(libro.Isbn) ||
                string.IsNullOrWhiteSpace(libro.Titulo) ||
                string.IsNullOrWhiteSpace(libro.Autor))
            {
                return false;
            }

            if (_datos.BuscarPorDni(libro.Dni.Trim()) != null)
            {
                return false;
            }

            return _datos.Agregar(libro.Dni.Trim(), libro.Isbn.Trim(), libro.Titulo.Trim(), libro.Autor.Trim(), libro.Disponible);
        }

        public bool ModificarLibro(Libro libro)
        {
            if (libro == null) return false;
            if (string.IsNullOrWhiteSpace(libro.Dni) ||
                string.IsNullOrWhiteSpace(libro.Isbn) ||
                string.IsNullOrWhiteSpace(libro.Titulo) ||
                string.IsNullOrWhiteSpace(libro.Autor))
            {
                return false;
            }

            return _datos.Modificar(libro.Dni.Trim(), libro.Isbn.Trim(), libro.Titulo.Trim(), libro.Autor.Trim(), libro.Disponible);
        }

        public bool EliminarLibro(string? dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return false;
            return _datos.Eliminar(dni.Trim());
        }
    }
}

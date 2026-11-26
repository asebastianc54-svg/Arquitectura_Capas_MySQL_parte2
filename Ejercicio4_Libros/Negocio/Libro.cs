namespace Ejercicio4_Libros.Negocio
{
    public class Libro
    {
        public string Dni { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public bool Disponible { get; set; }

        public Libro(string dni, string isbn, string titulo, string autor, bool disponible)
        {
            Dni = dni;
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Disponible = disponible;
        }
    }
}

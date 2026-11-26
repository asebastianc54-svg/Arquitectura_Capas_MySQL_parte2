using MySql.Data.MySqlClient;

namespace Ejercicio4_Libros.Datos
{
    public class LibroDatos
    {
        private string _conexionString = "Server=localhost;Database=biblioteca_db;Uid=root;Pwd=;";

        public (string Dni, string Isbn, string Titulo, string Autor, bool Disponible)? BuscarPorDni(string dni)
        {
            string query = "SELECT Dni, Isbn, Titulo, Autor, Disponible FROM libro WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string dniDb = reader["Dni"].ToString() ?? string.Empty;
                        string isbnDb = reader["Isbn"].ToString() ?? string.Empty;
                        string tituloDb = reader["Titulo"].ToString() ?? string.Empty;
                        string autorDb = reader["Autor"].ToString() ?? string.Empty;
                        bool disponibleDb = Convert.ToBoolean(reader["Disponible"]);

                        return (dniDb, isbnDb, tituloDb, autorDb, disponibleDb);
                    }
                }
            }

            return null;
        }

        public bool Agregar(string dni, string isbn, string titulo, string autor, bool disponible)
        {
            string query = "INSERT INTO libro (Dni, Isbn, Titulo, Autor, Disponible) VALUES (@Dni, @Isbn, @Titulo, @Autor, @Disponible)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Isbn", isbn);
                comando.Parameters.AddWithValue("@Titulo", titulo);
                comando.Parameters.AddWithValue("@Autor", autor);
                comando.Parameters.AddWithValue("@Disponible", disponible);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Modificar(string dni, string nuevoIsbn, string nuevoTitulo, string nuevoAutor, bool nuevaDisponible)
        {
            string query = "UPDATE libro SET Isbn = @Isbn, Titulo = @Titulo, Autor = @Autor, Disponible = @Disponible WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Isbn", nuevoIsbn);
                comando.Parameters.AddWithValue("@Titulo", nuevoTitulo);
                comando.Parameters.AddWithValue("@Autor", nuevoAutor);
                comando.Parameters.AddWithValue("@Disponible", nuevaDisponible);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Eliminar(string dni)
        {
            string query = "DELETE FROM libro WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
    }
}

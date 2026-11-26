using MySql.Data.MySqlClient;

namespace Ejercicio2_Alumnos.Datos
{
    public class AlumnoDatos
    {
        private string _conexionString = "Server=localhost;Database=academia_db;Uid=root;Pwd=;";

        public (string Dni, int Legajo, string Nombre, string Condicion)? BuscarPorDni(string dni)
        {
            string query = "SELECT Dni, Legajo, Nombre, Condicion FROM alumno WHERE Dni = @Dni";

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
                        int legajoDb = Convert.ToInt32(reader["Legajo"]);
                        string nombreDb = reader["Nombre"].ToString() ?? string.Empty;
                        string condicionDb = reader["Condicion"].ToString() ?? string.Empty;

                        return (dniDb, legajoDb, nombreDb, condicionDb);
                    }
                }
            }

            return null;
        }

        public bool Agregar(string dni, int legajo, string nombre, string condicion)
        {
            string query = "INSERT INTO alumno (Dni, Legajo, Nombre, Condicion) VALUES (@Dni, @Legajo, @Nombre, @Condicion)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Legajo", legajo);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Condicion", condicion);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Modificar(string dni, int nuevoLegajo, string nuevoNombre, string nuevaCondicion)
        {
            string query = "UPDATE alumno SET Legajo = @Legajo, Nombre = @Nombre, Condicion = @Condicion WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Legajo", nuevoLegajo);
                comando.Parameters.AddWithValue("@Nombre", nuevoNombre);
                comando.Parameters.AddWithValue("@Condicion", nuevaCondicion);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Eliminar(string dni)
        {
            string query = "DELETE FROM alumno WHERE Dni = @Dni";

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

using MySql.Data.MySqlClient;

namespace Ejercicio3_Vehiculos.Datos
{
    public class VehiculoDatos
    {
        private string _conexionString = "Server=localhost;Database=estacionamiento_db;Uid=root;Pwd=;";

        public (string Dni, string Patente, string Modelo, bool TieneDeuda)? BuscarPorDni(string dni)
        {
            string query = "SELECT Dni, Patente, Modelo, TieneDeuda FROM vehiculo WHERE Dni = @Dni";

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
                        string patenteDb = reader["Patente"].ToString() ?? string.Empty;
                        string modeloDb = reader["Modelo"].ToString() ?? string.Empty;
                        bool tieneDeudaDb = Convert.ToBoolean(reader["TieneDeuda"]);

                        return (dniDb, patenteDb, modeloDb, tieneDeudaDb);
                    }
                }
            }

            return null;
        }

        public bool Agregar(string dni, string patente, string modelo, bool tieneDeuda)
        {
            string query = "INSERT INTO vehiculo (Dni, Patente, Modelo, TieneDeuda) VALUES (@Dni, @Patente, @Modelo, @TieneDeuda)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Patente", patente);
                comando.Parameters.AddWithValue("@Modelo", modelo);
                comando.Parameters.AddWithValue("@TieneDeuda", tieneDeuda);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Modificar(string dni, string nuevaPatente, string nuevoModelo, bool nuevaTieneDeuda)
        {
            string query = "UPDATE vehiculo SET Patente = @Patente, Modelo = @Modelo, TieneDeuda = @TieneDeuda WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Patente", nuevaPatente);
                comando.Parameters.AddWithValue("@Modelo", nuevoModelo);
                comando.Parameters.AddWithValue("@TieneDeuda", nuevaTieneDeuda);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Eliminar(string dni)
        {
            string query = "DELETE FROM vehiculo WHERE Dni = @Dni";

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

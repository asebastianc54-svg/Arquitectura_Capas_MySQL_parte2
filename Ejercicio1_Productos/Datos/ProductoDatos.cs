using MySql.Data.MySqlClient;

namespace Ejercicio1_Productos.Datos
{
    public class ProductoDatos
    {
        private string _conexionString = "Server=localhost;Database=comercio_db;Uid=root;Pwd=;";

        public (string Dni, string Codigo, string Nombre, decimal Precio)? BuscarPorDni(string dni)
        {
            string query = "SELECT Dni, Codigo, Nombre, Precio FROM producto WHERE Dni = @Dni";

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
                        string codigoDb = reader["Codigo"].ToString() ?? string.Empty;
                        string nombreDb = reader["Nombre"].ToString() ?? string.Empty;
                        decimal precioDb = Convert.ToDecimal(reader["Precio"]);

                        return (dniDb, codigoDb, nombreDb, precioDb);
                    }
                }
            }

            return null;
        }

        public bool Agregar(string dni, string codigo, string nombre, decimal precio)
        {
            string query = "INSERT INTO producto (Dni, Codigo, Nombre, Precio) VALUES (@Dni, @Codigo, @Nombre, @Precio)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Codigo", codigo);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Precio", precio);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Modificar(string dni, string nuevoCodigo, string nuevoNombre, decimal nuevoPrecio)
        {
            string query = "UPDATE producto SET Codigo = @Codigo, Nombre = @Nombre, Precio = @Precio WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Codigo", nuevoCodigo);
                comando.Parameters.AddWithValue("@Nombre", nuevoNombre);
                comando.Parameters.AddWithValue("@Precio", nuevoPrecio);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Eliminar(string dni)
        {
            string query = "DELETE FROM producto WHERE Dni = @Dni";

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

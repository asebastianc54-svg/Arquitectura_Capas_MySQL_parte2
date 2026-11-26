using MySql.Data.MySqlClient;

namespace Ejercicio5_Empleados.Datos
{
    public class EmpleadoDatos
    {
        private string _conexionString = "Server=localhost;Database=rrhh_db;Uid=root;Pwd=;";

        public (string Dni, int Id, string Nombre, string Puesto, string Departamento)? BuscarPorDni(string dni)
        {
            string query = "SELECT Dni, Id, Nombre, Puesto, Departamento FROM empleado WHERE Dni = @Dni";

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
                        int idDb = Convert.ToInt32(reader["Id"]);
                        string nombreDb = reader["Nombre"].ToString() ?? string.Empty;
                        string puestoDb = reader["Puesto"].ToString() ?? string.Empty;
                        string departamentoDb = reader["Departamento"].ToString() ?? string.Empty;

                        return (dniDb, idDb, nombreDb, puestoDb, departamentoDb);
                    }
                }
            }

            return null;
        }

        public bool Agregar(string dni, int id, string nombre, string puesto, string departamento)
        {
            string query = "INSERT INTO empleado (Dni, Id, Nombre, Puesto, Departamento) VALUES (@Dni, @Id, @Nombre, @Puesto, @Departamento)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Id", id);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Puesto", puesto);
                comando.Parameters.AddWithValue("@Departamento", departamento);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Modificar(string dni, int nuevoId, string nuevoNombre, string nuevoPuesto, string nuevoDepartamento)
        {
            string query = "UPDATE empleado SET Id = @Id, Nombre = @Nombre, Puesto = @Puesto, Departamento = @Departamento WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Id", nuevoId);
                comando.Parameters.AddWithValue("@Nombre", nuevoNombre);
                comando.Parameters.AddWithValue("@Puesto", nuevoPuesto);
                comando.Parameters.AddWithValue("@Departamento", nuevoDepartamento);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool Eliminar(string dni)
        {
            string query = "DELETE FROM empleado WHERE Dni = @Dni";

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

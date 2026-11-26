namespace Ejercicio5_Empleados.Negocio
{
    public class Empleado
    {
        public string Dni { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Puesto { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;

        public Empleado(string dni, int id, string nombre, string puesto, string departamento)
        {
            Dni = dni;
            Id = id;
            Nombre = nombre;
            Puesto = puesto;
            Departamento = departamento;
        }
    }
}

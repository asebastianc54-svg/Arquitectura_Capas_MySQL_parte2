namespace Ejercicio2_Alumnos.Negocio
{
    public class Alumno
    {
        public string Dni { get; set; } = string.Empty;
        public int Legajo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Condicion { get; set; } = string.Empty;

        public Alumno(string dni, int legajo, string nombre, string condicion)
        {
            Dni = dni;
            Legajo = legajo;
            Nombre = nombre;
            Condicion = condicion;
        }
    }
}

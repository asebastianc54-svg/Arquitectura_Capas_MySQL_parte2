namespace Ejercicio3_Vehiculos.Negocio
{
    public class Vehiculo
    {
        public string Dni { get; set; } = string.Empty;
        public string Patente { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public bool TieneDeuda { get; set; }

        public Vehiculo(string dni, string patente, string modelo, bool tieneDeuda)
        {
            Dni = dni;
            Patente = patente;
            Modelo = modelo;
            TieneDeuda = tieneDeuda;
        }
    }
}

namespace Ejercicio1_Productos.Negocio
{
    public class Producto
    {
        public string Dni { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }

        public Producto(string dni, string codigo, string nombre, decimal precio)
        {
            Dni = dni;
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
        }
    }
}

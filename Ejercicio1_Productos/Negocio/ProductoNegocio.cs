using Ejercicio1_Productos.Datos;

namespace Ejercicio1_Productos.Negocio
{
    public class ProductoNegocio
    {
        private readonly ProductoDatos _datos = new ProductoDatos();

        public Producto? ConsultarPorDni(string? dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                return null;
            }

            var registro = _datos.BuscarPorDni(dni.Trim());
            if (registro == null)
            {
                return null;
            }

            return new Producto(registro.Value.Dni, registro.Value.Codigo, registro.Value.Nombre, registro.Value.Precio);
        }

        public bool AgregarProducto(Producto producto)
        {
            if (producto == null) return false;
            if (string.IsNullOrWhiteSpace(producto.Dni) ||
                string.IsNullOrWhiteSpace(producto.Codigo) ||
                string.IsNullOrWhiteSpace(producto.Nombre) ||
                producto.Precio < 0)
            {
                return false;
            }

            string codigoLimpio = producto.Codigo.Trim();
            if (!codigoLimpio.StartsWith("PROD-", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (_datos.BuscarPorDni(producto.Dni.Trim()) != null)
            {
                return false;
            }

            return _datos.Agregar(producto.Dni.Trim(), codigoLimpio, producto.Nombre.Trim(), producto.Precio);
        }

        public bool ModificarProducto(Producto producto)
        {
            if (producto == null) return false;
            if (string.IsNullOrWhiteSpace(producto.Dni) ||
                string.IsNullOrWhiteSpace(producto.Codigo) ||
                string.IsNullOrWhiteSpace(producto.Nombre) ||
                producto.Precio < 0)
            {
                return false;
            }

            string codigoLimpio = producto.Codigo.Trim();
            if (!codigoLimpio.StartsWith("PROD-", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return _datos.Modificar(producto.Dni.Trim(), codigoLimpio, producto.Nombre.Trim(), producto.Precio);
        }

        public bool EliminarProducto(string? dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return false;
            return _datos.Eliminar(dni.Trim());
        }
    }
}

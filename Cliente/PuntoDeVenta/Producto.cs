using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuntoDeVenta
{
    class Producto
    {

        public string nombre { get; set; }
        public string marca { get; set; }
        public string descripcion { get; set; }
        public string precioVenta { get; set; }
        public string precioCompra { get; set; }
        public string caducidad { get; set; }
        public int stock { get; set; }
        public int medida { get; set; }
        public int departamento { get; set; }
        public int provedor { get; set; }
        public int idProducto { get; set; }
    }
}

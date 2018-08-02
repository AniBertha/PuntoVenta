using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuntoDeVenta
{
    class Usuario
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string fecha_nacimiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public int permiso { get; set; }
        public int idUsuario { get; set; }

    }
}

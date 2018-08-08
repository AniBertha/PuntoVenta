using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuntoDeVenta
{
    public class Globales
    {
        public static String f;
        public static FormUsuarios formUsuarios = new FormUsuarios();
        public static FormProductos formProductos = new FormProductos();
        public static FormProveedores formProveedores = new FormProveedores();
        public static void InstanciarUsuarios()
        {
            formUsuarios = new FormUsuarios();
        }
        public static void InstanciarProductos()
        {
            formProductos = new FormProductos();
        }
        public static void InstanciarProveedores()
        {
            formProveedores = new FormProveedores();
        }
    }
}

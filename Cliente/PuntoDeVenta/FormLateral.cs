using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class FormLateral : Form
    {
        public FormLateral()
        {
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (Globales.f == "Productos")
            {
                Globales.formProductos.Close();
                Globales.InstanciarProductos();
                Globales.formUsuarios.Show();
            }
            else if (Globales.f == "Proveedores")
            {
                Globales.formProveedores.Close();
                Globales.InstanciarProveedores();
                Globales.formUsuarios.Show();
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            if (Globales.f == "Productos")
            {
                Globales.formProductos.Close();
                Globales.InstanciarProductos();
                Globales.formProveedores.Show();
            }
            else if (Globales.f == "Usuarios")
            {
                Globales.formUsuarios.Close();
                Globales.InstanciarUsuarios();
                Globales.formProveedores.Show();
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            if (Globales.f == "Proveedores")
            {
                Globales.formProveedores.Close();
                Globales.InstanciarProveedores();
                Globales.formProductos.Show();
            }
            else if (Globales.f == "Usuarios")
            {
                Globales.formUsuarios.Close();
                Globales.InstanciarUsuarios();
                Globales.formProductos.Show();
            }
        }
    }
}

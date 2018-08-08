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
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Globales.formUsuarios.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Globales.formProductos.Show();
            this.Close();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Globales.formProveedores.Show();
            this.Close();
        }
    }
}

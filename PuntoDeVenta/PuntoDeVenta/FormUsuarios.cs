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
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            MenuLateral frmLogin = new MenuLateral();
            frmLogin.TopLevel = false;
            frmLogin.Parent = panel1;
            frmLogin.Show();
            frmLogin.BringToFront();


            AgregarUsuario agregarUsuario = new AgregarUsuario();
            agregarUsuario.TopLevel = false;
            agregarUsuario.Parent = panel2;
            agregarUsuario.Show();
            agregarUsuario.BringToFront();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    String cadena = client.buscarLogin(Convert.ToInt16(txtUser.Text), txtPwd.Text);
                    //DataTable dt = (DataTable)JsonConvert.DeserializeObject(client.buscarLogin(Convert.ToInt16(txtUser.Text), txtPwd.Text), typeof(DataTable));
                    //String permiso = dt.Rows[8].ToString();
                    String permiso = cadena.Substring(cadena.Length - 3, 1);
                    if (cadena != "[]")
                    {
                        FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal();
                        FormLateral formLat = new FormLateral();
                        formMenuPrincipal.Show();
                        if (permiso == "0")
                        {
                            formMenuPrincipal.btnUsers.Enabled = false;
                            formMenuPrincipal.btnUsers.BackColor = Color.Gray;
                            formMenuPrincipal.btnProveedores.Enabled = false;
                            formMenuPrincipal.btnProveedores.BackColor = Color.Gray;

                            formLat.btnUsers.Enabled = false;
                            formLat.btnUsers.BackColor = Color.Gray;
                            formLat.btnProveedores.Enabled = false;
                            formLat.btnProveedores.BackColor = Color.Gray;
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Id de usuario o contraseña incorrectos.");
                    txtPwd.Text = "";
                    txtUser.Text = "";

                    }
                    

                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                }
            }
            

        }
    }
}

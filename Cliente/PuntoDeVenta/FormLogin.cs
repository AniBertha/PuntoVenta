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
                    
                    if (cadena != "[]")
                    {
                        FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal();
                        formMenuPrincipal.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Datos incorrectos");
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

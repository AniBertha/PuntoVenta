using System;
using Newtonsoft.Json;
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
            FormLateral frmLat = new FormLateral();
            frmLat.TopLevel = false;
            frmLat.Parent = panel1;
            frmLat.Show();
            frmLat.BringToFront();
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(client.cargarUsuario(), typeof(DataTable));

                    dataGridView1.DataSource = dt;
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                }
            }
        }
        string data, data2 = "[";

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Usuario json = new Usuario();
            json.nombre = txtNombre.Text;
            json.apellido = txtApellidos.Text;
            json.fecha_nacimiento = txtNacimiento.Text;
            json.direccion = txtDireccion.Text;
            json.telefono = txtTelefono.Text;
            json.correo = txtCorreo.Text;
            json.password = txtPassword.Text;
            json.permiso = comboBox1.SelectedIndex;
            json.idUsuario = Convert.ToInt16( txtID.Text);
            data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented) + "]";
            data2 += data;
            
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    client.actualizarUsuario(data2);
                    MessageBox.Show("Usuario modificado correctamente.");
                    data = "";
                    data2 = "[";
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario json = new Usuario();
           json.idUsuario = Convert.ToInt16(txtID.Text);
           data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);
            data2 += data;
            data2 += "]";
            txtID.Text = data2;
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    client.bajaUsuario(data2);
                    
                    MessageBox.Show("¡Usuario eliminado! :)");
                    data = "";
                    data2 = "[";
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                    
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario json = new Usuario();
            json.nombre = txtNombre.Text;
            json.apellido = txtApellidos.Text;
           
            json.fecha_nacimiento = txtNacimiento.Text;
            json.direccion = txtDireccion.Text;
            json.telefono = txtTelefono.Text;
            json.correo = txtCorreo.Text;
            json.password = txtPassword.Text;
            json.permiso = comboBox1.SelectedIndex;
            data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented) + "]";
            data2 += data;
            txtID.Text = data2;
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    client.altaUsuario(data2);
                    MessageBox.Show("Usuario Insertado! :)");
                    data = "";
                    data2 = "[";
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                }
            }

        }
    }
}

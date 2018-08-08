using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PuntoDeVenta;

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
            ActualizarTabla();
            Globales.f = "Usuarios";
        }
        private void btnProductos_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ActualizarTabla()
        {
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
                    ActualizarTabla();
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
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    client.bajaUsuario(data2);
                    
                    MessageBox.Show("¡Usuario eliminado! :)");
                    data = "";
                    data2 = "[";
                    ActualizarTabla();
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                    
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtID.Text  = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtNacimiento.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtCorreo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtPassword.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(client.buscarUsuario(txtBuscar.Text), typeof(DataTable));

                    dataGridView1.DataSource = dt;
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtNacimiento.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtPassword.Text = "";
            ActualizarTabla();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtApellidos.Text != "" && txtDireccion.Text != "" && txtNacimiento.Text != "" && txtTelefono.Text != "" && txtCorreo.Text != "" && txtPassword.Text != "" && comboBox1.Text != "")
            {
                if (MessageBox.Show("¿Esta seguro Agregar este Usuario al sistema?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
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

                    using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
                    {
                        try
                        {
                            client.altaUsuario(data2);
                            MessageBox.Show("Usuario Insertado! :)");
                            data = "";
                            data2 = "[";
                            ActualizarTabla();
                        }
                        catch
                        {
                            MessageBox.Show("No sirvio :(");
                        }
                    }
                }
                }
            else
                MessageBox.Show("Por favor llena todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }
    }
}

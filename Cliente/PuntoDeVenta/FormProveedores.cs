using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class FormProveedores : Form
    {
        public FormProveedores()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
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
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(client.cargarProveedor(), typeof(DataTable));

                    dgvTabla.DataSource = dt;
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                }
            }
            Globales.f = "Proveedores";
        }
        string data, data2 = "[";
        public void ActualizarTabla()
        {
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(client.cargarProveedor(), typeof(DataTable));

                    dgvTabla.DataSource = dt;
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                }
            }
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (txtRazonSocial.Text == "" || txtDomicilioFiscal.Text == "" || txtRFC.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "")
            {
                MessageBox.Show("Falta rellenar uno o mas campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Proveedor json = new Proveedor();
                //json.IDProveedor = Convert.ToInt16(txtID.Text);
                json.RazonSocial = txtRazonSocial.Text;
                json.DomicilioFiscal = txtDomicilioFiscal.Text;
                json.RFC = txtRFC.Text;
                json.Telefono = txtTelefono.Text;
                json.Correo = txtCorreo.Text;
                data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented) + "]";
                data2 += data;
                //txtID.Text = data2;
                using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
                {
                    try
                    {
                        client.altaProveedor(data2);
                        MessageBox.Show("Proveedor Insertado! :)");
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtRazonSocial.Text == "" || txtDomicilioFiscal.Text == "" || txtRFC.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "")
            {
                MessageBox.Show("Falta rellenar uno o mas campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Proveedor json = new Proveedor();
                //json.IDProveedor = Convert.ToInt16(txtID.Text);
                json.RazonSocial = txtRazonSocial.Text;
                json.DomicilioFiscal = txtDomicilioFiscal.Text;
                json.RFC = txtRFC.Text;
                json.Telefono = txtTelefono.Text;
                json.Correo = txtCorreo.Text;
                data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented) + "]";
                data2 += data;

                using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
                {
                    try
                    {
                        client.actualizarProveedor(data2);
                        MessageBox.Show("Proveedor modificado correctamente.");
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Está seguro de eliminar este elemento? Esta acción no se puede deshacer.", "Eliminar proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Proveedor json = new Proveedor();
                json.IDProveedor = Convert.ToInt16(txtID.Text);
                data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);
                data2 += data;
                data2 += "]";
                txtID.Text = data2;
                using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
                {
                    try
                    {
                        client.bajaProveedor(data2);

                        MessageBox.Show("¡Proveedor eliminado! :)");
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtRazonSocial.Text = "";
            txtDomicilioFiscal.Text = "";
            txtRFC.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                MessageBox.Show("Ingrese el ID del producto a buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47)
            {
                MessageBox.Show("Solo se admiten numeros para este campo", "Caracter no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTabla_MouseClick(object sender, MouseEventArgs e)
        {
            txtID.Text = dgvTabla.CurrentRow.Cells[0].Value.ToString();
            txtRazonSocial.Text = dgvTabla.CurrentRow.Cells[1].Value.ToString();
            txtDomicilioFiscal.Text = dgvTabla.CurrentRow.Cells[2].Value.ToString();
            txtRFC.Text = dgvTabla.CurrentRow.Cells[3].Value.ToString();
            txtTelefono.Text = dgvTabla.CurrentRow.Cells[4].Value.ToString();
            txtCorreo.Text = dgvTabla.CurrentRow.Cells[5].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormProveedores_Load(object sender, EventArgs e)
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
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(client.cargarProveedor(), typeof(DataTable));

                    dgvTabla.DataSource = dt;
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                }
            }
            Globales.f = "Proveedores";
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {

                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(client.buscarProveedor(txtBusqueda.Text), typeof(DataTable));

                    dgvTabla.DataSource = dt;
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                }
            }
        }

        
    }
}

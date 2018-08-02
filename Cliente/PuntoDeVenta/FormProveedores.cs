using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class FormProveedores : Form
    {
        public FormProveedores()
        {
            InitializeComponent();
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            Proveedor json = new Proveedor();
            json.IDProveedor = Convert.ToInt16(txtID.Text);
            json.RazonSocial = txtRazonSocial.Text;
            json.DomicilioFiscal = txtDomicilioFiscal.Text;
            json.RFC = txtRFC.Text;
            json.Telefono = txtTelefono.Text;
            json.Correo = txtCorreo.Text;
            data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented) + "]";
            data2 += data;
            txtID.Text = data2;
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    client.altaProveedor(data2);
                    MessageBox.Show("Proveedor Insertado! :)");
                    data = "";
                    data2 = "[";
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
            Proveedor json = new Proveedor();
            json.IDProveedor = Convert.ToInt16(txtID.Text);
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
                    client.actualizarUsuario(data2);
                    MessageBox.Show("Proveedor modificado correctamente.");
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
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(client.cargarUsuario(), typeof(DataTable));

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

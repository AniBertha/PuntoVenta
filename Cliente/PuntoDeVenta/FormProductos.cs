using Newtonsoft.Json;
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
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            //fgdf
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

        string data, data2 = "[";

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto json = new Producto();
            json.nombre = txtNombre.Text;
            json.marca = txtMarca.Text;

            json.descripcion = txtDescripcion.Text;
            json.precioVenta= textPV.Text;
            json.precioCompra = textPC.Text;
            json.caducidad= textCaducidad.Text;
            json.stock = Convert.ToInt16(txtCantidad.Text);
            json.medida = cbUnidad.SelectedIndex;
            json.departamento = cbDepartamento.SelectedIndex;
            json.provedor= cbProvedor.SelectedIndex;
            data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented) + "]";
            data2 += data;
            txtID.Text = data2;
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                  //  client.altaProducto(data2);
                    MessageBox.Show("Producto Insertado! :)");
                    data = "";
                    data2 = "[";
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                }
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            Producto json = new Producto();
            json.nombre = txtNombre.Text;
            json.marca = txtMarca.Text;

            json.descripcion = txtDescripcion.Text;
            json.precioVenta = textPV.Text;
            json.precioCompra = textPC.Text;
            json.caducidad = textCaducidad.Text;
            json.stock = Convert.ToInt16(txtCantidad.Text);
            json.medida = cbUnidad.SelectedIndex;
            json.departamento = cbDepartamento.SelectedIndex;
            json.provedor = cbProvedor.SelectedIndex;
            json.idProducto = Convert.ToInt16(txtID.Text);
            data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented) + "]";
            data2 += data;

            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
            //        client.actualizarProducto(data2);
                    MessageBox.Show("Producto modificado correctamente.");
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
            Producto json = new Producto();
            json.idProducto = Convert.ToInt16(txtID.Text);
            data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);
            data2 += data;
            data2 += "]";
            txtID.Text = data2;
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
         //           client.bajaUsuario(data2);

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto json = new Producto();
            json.nombre = txtNombre.Text;
            json.marca = txtMarca.Text;

            json.descripcion = txtDescripcion.Text;
            json.precioVenta = textPV.Text;
            json.precioCompra = textPC.Text;
            json.caducidad = textCaducidad.Text;
            json.stock = Convert.ToInt16(txtCantidad.Text);
            json.medida = cbUnidad.SelectedIndex;
            json.departamento = cbDepartamento.SelectedIndex;
            json.provedor = cbProvedor.SelectedIndex;
            json.idProducto = Convert.ToInt16(txtID.Text);
            data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented) + "]";
            data2 += data;

            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    client.buscarProducto(data2);
                    MessageBox.Show("Resultados");
                    data = "";
                    data2 = "[";
                }
                catch
                {
                    MessageBox.Show("No sirvio :(");
                }
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}

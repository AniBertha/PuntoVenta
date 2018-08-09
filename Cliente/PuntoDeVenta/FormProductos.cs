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
            ActualizarTabla();
            ActualizarDepartamento();
            Globales.f = "Productos";
        }


        public void ActualizarDepartamento()
        {
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    String respuestaDepa= client.cargarCatDepartamento();
                    String respuestaProv= client.cargarCatProveedor();
                    String respuestaMedida = client.cargarCatMedida();
                    //MessageBox.Show("y ahora"+respuesta);
                    var a = JsonConvert.DeserializeObject<List<Departamento>>(respuestaDepa);
                    var b = JsonConvert.DeserializeObject<List<Proveedor>>(respuestaProv);
                    var c= JsonConvert.DeserializeObject<List<Medida>>(respuestaMedida);
                    foreach (var depa in a)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Text = depa.nombre;
                        item.Value = depa.idDepartamento;
                        cbDepartamento.Items.Add(item);
                    }

                    foreach (var prov in b)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Text = prov.RazonSocial;
                        item.Value = prov.IDProveedor;
                        cbProvedor.Items.Add(item);
                    }

                    foreach (var med in c)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Text = med.nombre;
                        item.Value = med.idMedida;
                        cbUnidad.Items.Add(item);
                    }
                }
                catch
                {
                    MessageBox.Show("No sirvio :(Auxilio");
                }
            }
        }


        public void ActualizarTabla()
        {
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(client.cargarProducto(), typeof(DataTable));
                    dgvTabla.DataSource = dt;
                }
                catch
                {
                    MessageBox.Show("No sirvio Tabla :(");
                }
            }
        }
        string data, data2 = "[";

       

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtMarca.Text != "" && txtDescripcion.Text != "" && cbDepartamento.Text != "" && cbProvedor.Text != "" && textPC.Text != "" && textPV.Text != "" && textCaducidad.Text != "" && txtCantidad.Text != "" && cbUnidad.Text != "")
            {
                if (MessageBox.Show("¿Esta seguro Agregar este este producto al sistema?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    Producto json = new Producto();
                    json.nombre = txtNombre.Text;
                    json.marca = txtMarca.Text;
                    json.descripcion= txtDescripcion.Text;
                    json.precioVenta = Convert.ToDecimal(textPV.Text); 
                    json.precioCompra = Convert.ToDecimal(textPC.Text);
                    json.caducidad = textCaducidad.Text;
                    json.stock = Convert.ToInt16(txtCantidad.Text);
                    json.medida = cbUnidad.SelectedIndex;
                    json.departamento = cbDepartamento.SelectedIndex;
                    json.provedor = cbProvedor.SelectedIndex;
                   
                    data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented) + "]";
                    data2 += data;

                    using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
                    {
                        try
                        {
                            client.altaProducto(data2);
                            MessageBox.Show("Producto Insertado! :)");
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            Producto json = new Producto();
            json.nombre = txtNombre.Text;
            json.marca = txtMarca.Text;
            json.descripcion = txtDescripcion.Text;
            json.precioVenta = Convert.ToDecimal(textPV.Text);
            json.precioCompra = Convert.ToDecimal(textPC.Text);
            json.caducidad = textCaducidad.Text;
            json.stock = Convert.ToInt16(txtCantidad.Text);
            json.medida = cbUnidad.SelectedIndex;
            json.departamento = cbDepartamento.SelectedIndex;
            json.provedor = cbProvedor.SelectedIndex;
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
            
            using (ServiceReference1.ServidorWebClient client = new ServiceReference1.ServidorWebClient())
            {
                try
                {

                    json.idProducto = Convert.ToInt32(txtID.Text);
                    data = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);
                    data2 += data;
                    data2 += "]";
                    txtID.Text = data2;
                    client.bajaProducto(data2);

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto json = new Producto();
            json.nombre = txtNombre.Text;
            json.marca = txtMarca.Text;
            json.descripcion = txtDescripcion.Text;
            json.precioVenta = Convert.ToDecimal(textPV.Text);
            json.precioCompra = Convert.ToDecimal(textPC.Text);
            json.caducidad = textCaducidad.Text;
            json.stock = Convert.ToInt16(txtCantidad.Text);
            json.medida = cbUnidad.SelectedIndex;
            json.departamento = cbDepartamento.SelectedIndex;
            json.provedor = cbProvedor.SelectedIndex;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.Collections;

namespace Geral_Boutique
{
    public partial class AggFactura : Form
    {
        public string elid = null;
        public string elcedula = null;
        public string elnombre = null;
        public string eltelefono = null;
        public string elsector = null;
        public string useractivo = null;
        ArrayList myAL = new ArrayList();
        public int cont_fila = 0;
        public static double total;
        public AggFactura()
        {
            InitializeComponent();

        }

        private void VerCliente_Click(object sender, EventArgs e)
        {
            useractivo = txtuseractivo.Text;
            Seleccion_Cliente sc = new Seleccion_Cliente();
            sc.textBox1.Text = useractivo;
            sc.textBox1.Visible = false;
            sc.Show();
            this.Close();
        }

        public void agregarcliente() {


            txtcedcli.Text = elid;
            txtnombrecli.Text = elnombre;

        }

        private void AggFactura_Load(object sender, EventArgs e)
        {
            DateTimeFormatInfo MxFormat = new CultureInfo("es-MX", false).DateTimeFormat;
            lblfecha.Text = DateTime.Now.ToString(MxFormat.ShortDatePattern);
            agregarcliente();

            Conexcion con = new Conexcion();
            con.abrir();
            int resultado = 1;
            con.abrir();
            string Codigo = "";
            int total1 = 0;
            try
            {
                SqlCommand sqd = new SqlCommand("Select Numero_Factura from Factura", con.sql);
                int hola = Convert.ToInt32(sqd.ExecuteScalar());
            }
            catch (Exception a)
            {
                System.Windows.Forms.MessageBox.Show("Error al crear el Codigo" + a.ToString());
            }
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            string codigo = dgvbuscarprod.SelectedRows[0].Cells["Codigo"].Value.ToString();
            string desc = dgvbuscarprod.SelectedRows[0].Cells["Descripcion"].Value.ToString();
            string precio = dgvbuscarprod.SelectedRows[0].Cells["PVenta"].Value.ToString();
            dataGridView2.Rows.Add(codigo, desc, precio);

            Venta_Prod.Text = precio;

            double total = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                total += Convert.ToDouble(row.Cells["Precio"].Value);
            }
            Cant_Prod.Text = Convert.ToString(total);
            label14.Text = Cant_Prod.Text;

        } */

        public DataTable cargarproductos()
        {
            DataTable dt = new DataTable();
            Conexcion con = new Conexcion();
            string strSql = "Select * from Productos";
            SqlDataAdapter da = new SqlDataAdapter(strSql, con.sql);
            da.Fill(dt);
            return dt;
        }

        private void Costo_Prod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se aceptan numeros en estos campos");
                e.Handled = true;
                return;
            }
        }

       /* private void datos()
        {
            try
            {
                //string precio = dataGridView2.CurrentCell.Value.ToString();
                string precio = dataGridView2.SelectedRows[0].Cells["Precio"].Value.ToString();
                int uno = Convert.ToInt32(precio);
                int dos = Convert.ToInt32(Cant_Prod.Text);
                Cant_Prod.Text = (dos - uno).ToString();
                label14.Text = (dos - uno).ToString();
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show("Todos los productos eliminados", "Notificacion", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Cant_Prod.Text = null;
                    label14.Text = null;
                    Venta_Prod.Text = null;
                }
            }
        } */

        private void checkBox1_Click(object sender, EventArgs e)
        {
            string resultado = null;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                if (Cant_Prod.Text == "") { MessageBox.Show("No hay total seleccionado"); }
                else
                {
                    string[] partes = Cant_Prod.Text.Split('$');
                    if (partes.Length >=1) { resultado = partes[1]; }
                    float uno = Convert.ToSingle(resultado);
                    double dos = ((uno * 0.18) + uno);
                    label14.Text = "Total con ITBS: RD$ "+(dos).ToString();
                }
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                if (Cant_Prod.Text == "RD$ 0") { MessageBox.Show("No hay total seleccionado"); }
                else
                {
                    float uno = Convert.ToSingle(resultado);
                    label14.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cont_fila != 0)
            {
                try
                {
                    MessageBox.Show("Esta parte se esta trabajando.");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void btncolocar_Click(object sender, EventArgs e)
        {
            bool valido = true;

            if (txtproducto.Text == "" || txtDescripcion.Text == "" || txtPrecio.Text == "" || txtCantidad.Text == "")
            {
                valido = false;
                MessageBox.Show("No ha seleccionado el producto correctamente");
            };
            if (valido == true)
            {
                bool existe = false;
                int num_fila = 0;

                if (cont_fila == 0)
                {
                    dataGridView1.Rows.Add(txtproducto.Text, txtDescripcion.Text, txtPrecio.Text, txtCantidad.Text);
                    double importe = Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[3].Value);
                    dataGridView1.Rows[cont_fila].Cells[4].Value = importe;

                    cont_fila++;

                    Venta_Prod.Text = txtPrecio.Text;

                    txtproducto.Text = "";
                    txtDescripcion.Text = "";
                    txtPrecio.Text = "";
                    txtCantidad.Text = "";
                }
                else
                {
                    foreach (DataGridViewRow Fila in dataGridView1.Rows)
                    {
                        if (Fila.Cells[0].Value.ToString() == txtproducto.Text)
                        {
                            existe = true;
                            num_fila = Fila.Index;
                        }
                    }
                    if (existe == true)
                    {
                        dataGridView1.Rows[num_fila].Cells[3].Value = (Convert.ToDouble(txtCantidad.Text) + Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value)).ToString();
                        double importe = Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value);

                        dataGridView1.Rows[num_fila].Cells[4].Value = importe;
                        Venta_Prod.Text = txtPrecio.Text;
                    }
                    else
                    {
                        dataGridView1.Rows.Add(txtproducto.Text, txtDescripcion.Text, txtPrecio.Text, txtCantidad.Text);
                        double importe = Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[3].Value);
                        dataGridView1.Rows[cont_fila].Cells[4].Value = importe;

                        cont_fila++;
                        Venta_Prod.Text = txtPrecio.Text;
                    }
                }

                total = 0;

                foreach (DataGridViewRow Fila in dataGridView1.Rows)
                {
                    total += Convert.ToDouble(Fila.Cells[4].Value);
                }

                Cant_Prod.Text = "RD$ " + total.ToString();
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (cont_fila > 0)
            {
                total = total - (Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value));
                Cant_Prod.Text = "RD$ " + total.ToString();
                txtproducto.Text = "";
                txtDescripcion.Text = "";
                txtPrecio.Text = "";
                txtCantidad.Text = "";
                Venta_Prod.Text = total.ToString();

                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

                cont_fila--;
            }
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            Seleccion_Producto SeleccPro = new Seleccion_Producto();          
            SeleccPro.ShowDialog();

            if (SeleccPro.DialogResult == DialogResult.OK)
            {
                 txtproducto.Text = SeleccPro.dgvbuscarprod.SelectedRows[0].Cells["Codigo"].Value.ToString();
                txtDescripcion.Text = SeleccPro.dgvbuscarprod.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = SeleccPro.dgvbuscarprod.SelectedRows[0].Cells["PVenta"].Value.ToString();

                txtCantidad.Focus();
            }
           
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        public void Nuevo()
        {
            txtproducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            Cant_Prod.Text = "RD$ 0";
            Venta_Prod.Text = "";
            txtcedcli.Text = "";
            txtnombrecli.Text = "";
            dataGridView1.Rows.Clear();
            cont_fila = 0;
            total = 0;
            VerCliente.Focus();
        }
    }
}

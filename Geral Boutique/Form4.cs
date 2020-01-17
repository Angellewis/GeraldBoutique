using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geral_Boutique
{
    public partial class AggProducto : Form
    {
        public AggProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Desc_prod.Text == "" || Marc_prod.Text == "" || comboBox1.Text == "" || Costo_Prod.Text == "" || Cant_Prod.Text == "")
            {
                MessageBox.Show("Por Favor Introduzca Los Datos completos", "Aviso!");
            }

            else if (NuevoUsuario.CrearProducto(Desc_prod.Text, Marc_prod.Text, comboBox1.Text, Costo_Prod.Text, Venta_Prod.Text, Convert.ToInt32(Cant_Prod.Text)) > 0)
            {

                MessageBox.Show("Producto agregado con exito", "Notificacion");
                Desc_prod.Text = "";
                Marc_prod.Text = "";
                comboBox1.Text = "";
                Costo_Prod.Text = "";
                Venta_Prod.Text = "";
                Cant_Prod.Text = "";
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se pudo agregar el producto.");
            }
        }
           
        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
            {
                int x, y, z, m;
                x = Convert.ToInt32(Costo_Prod.Text);
                z = Convert.ToInt32(txtganancia.Text);
                m = x + z;
                if (Venta_Prod.Text == "")
                {
                    Venta_Prod.Text = (m).ToString();
                }
                else {
                    y = Convert.ToInt32(Venta_Prod.Text);
                    Venta_Prod.Text = (y + z).ToString();

                }
            }
            else if (checkBox2.CheckState == CheckState.Unchecked)
            {
                int x, y, z, m;
                x = Convert.ToInt32(Costo_Prod.Text);
                y = Convert.ToInt32(Venta_Prod.Text);
                z = Convert.ToInt32(txtganancia.Text);
                m = y - z;
                Venta_Prod.Text = m.ToString();
            }
        }

        private void AggProducto_Load(object sender, EventArgs e)
        {
            if (txtganancia.Text == "")
            {
                checkBox2.Enabled = false;
            }
        }

        private void txtganancia_KeyUp(object sender, KeyEventArgs e)
        {
            checkBox2.Enabled = true;

            if (txtganancia.Text == "")
            {
                checkBox2.Enabled = false;
            }
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
    }
}

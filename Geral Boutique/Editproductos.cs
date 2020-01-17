using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geral_Boutique
{
    public partial class Editproductos : Form
    {
        public string elid = null;
        public string elmarca = null;
        public string elcategoria = null;
        public string eldescripcion = null;
        public string elpcosto = null;
        public string elpventa = null;
        public string elcantidad = null;
        public string hola = null;
        public Editproductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txteditmarca.Text == "" || txteditdesc.Text == "" || txteditcategoria.Text == "" || txteditcant.Text == "" || txteditpcosto.Text == "" || txteditpventa.Text == "")
            {
                MessageBox.Show("Datos Incompletos");
            }
            else
            {
                Form1 fr = new Form1();
                Conexcion con = new Conexcion();
                con.abrir();
                SqlCommand cmd = new SqlCommand("UPDATE Productos SET Marca='" + txteditmarca.Text + "',Descripcion='" + txteditdesc.Text + "',Categoria='" + txteditcategoria.Text + "',PCosto='" + txteditpcosto.Text + "',PVenta='" + txteditpventa.Text + "',Cantidad='" + Convert.ToInt32(txteditcant.Text) + "' where Codigo= @ID", con.sql);
                cmd.Parameters.Add(new SqlParameter("@ID", elid));
                cmd.ExecuteNonQuery();
                con.close();
                MessageBox.Show("Edicion Completada", "Notificacion");
                this.Close();
            }
        }

        private void Editproductos_Load(object sender, EventArgs e)
        {
            textBox1.Text = hola;
            textBox1.Visible = false;
            txteditmarca.Text = elmarca;
            txteditdesc.Text = eldescripcion;
            txteditcategoria.Text = elcategoria;
            txteditcant.Text = elcantidad;
            txteditpcosto.Text = elpcosto;
            txteditpventa.Text = elpventa;
        }

        private void Editproductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            fr.UserActivo.Text = hola;
            fr.button2_Click(this, null);
        }

        private void txteditpventa_KeyPress(object sender, KeyPressEventArgs e)
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

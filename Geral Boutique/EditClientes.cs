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
    public partial class EditClientes : Form
    {
        public string elid = null;
        public string elnombre = null;
        public string elcedula = null;
        public string eltelefono = null;
        public string elsector = null;
        public string hola = null;
        public EditClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txteditced.Text == "" || txteditnom.Text == "" || txtedittel.Text == "" || txteditsect.Text == "")
            {
                MessageBox.Show("Datos Incompletos");
            }
            else
            {
                Form1 fr = new Form1();
                Conexcion con = new Conexcion();
                con.abrir();
                SqlCommand cmd = new SqlCommand("UPDATE Clientes SET Cedula='" + txteditced.Text + "',Nombre='" + txteditnom.Text + "',Telefono='" + txtedittel.Text + "',Sector='" + txteditsect.Text + "' where Id_Clientes= @ID", con.sql);
                cmd.Parameters.Add(new SqlParameter("@ID", elid));
                cmd.ExecuteNonQuery();
                con.close();
                MessageBox.Show("Edicion Completada", "Notificacion");
                this.Close();
                fr.UserActivo.Text = hola;
                fr.button3_Click(this, null);
            }
        }

        private void EditClientes_Load(object sender, EventArgs e)
        {
            textBox1.Text = hola;
            textBox1.Visible = false;
            txteditnom.Text = elnombre;
            txteditced.Text = elcedula;
            txtedittel.Text = eltelefono;
            txteditsect.Text = elsector;

        }

        private void EditClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            fr.UserActivo.Text = hola;
            fr.button3_Click(this, null);
        }
    }
}

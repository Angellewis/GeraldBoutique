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
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        public void logear(string usuario, string clave)
        {
            try
            {
                Conexcion con = new Conexcion();
                con.abrir();
                SqlCommand cmd = new SqlCommand("SELECT Nombre, Tipo_Usr FROM Usuario WHERE Usuario = @usuario AND Clave =@pass", con.sql);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("pass", clave);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Admin" || dt.Rows[0][1].ToString() == "admin")
                    {
                        MessageBox.Show("Bienvenido " + dt.Rows[0][0].ToString());
                        Form1 fr = new Form1();
                        String control = txtusuariologin.Text;
                        fr.UserActivo.Text = ("Usuario Activo: " + control);
                        fr.Show();
                        this.Hide();
                        con.close();

                    }
                    else if (dt.Rows[0][1].ToString() == "Usuario" || dt.Rows[0][1].ToString() == "usuario")
                    {
                        MessageBox.Show("Bienvenido " + dt.Rows[0][0].ToString());
                        Form1 fr = new Form1();
                        String control = txtusuariologin.Text;
                        fr.UserActivo.Text = ("Usuario Activo: " + control);
                        fr.Show();
                        this.Hide();
                        con.close();
                    }
                }
                else
                {
                    label3.Text = "DATOS ERRONEOS";
                }

            }
            catch (Exception a)
            {

            }
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            if (txtusuariologin.Text == "" || txtcontrausr.Text == "")
            {
                MessageBox.Show("Introduzca todos sus datos por favor");
            }
            else
            {
                logear(txtusuariologin.Text, txtcontrausr.Text);

            }

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Form1 fr = new Form1();
                frmlogin fm = new frmlogin();
                if (txtusuariologin.Text == "" || txtcontrausr.Text == "")
                {
                    MessageBox.Show("Introduzca todos sus datos por favor");
                }
                else
                {
                    logear(txtusuariologin.Text, txtcontrausr.Text);

                }

            }
        }
    }
}

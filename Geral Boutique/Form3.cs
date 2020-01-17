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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public DataTable obtenerContactos()
        {
            DataTable dt = new DataTable();
            Conexcion con = new Conexcion(); 
            string strSql = "Select * from Usuario";
            SqlDataAdapter da = new SqlDataAdapter(strSql, con.sql);
            da.Fill(dt);
            return dt;
        }
        private void mostarDatos()
        {
            DataTable dt = obtenerContactos();
            dataGridView1.DataSource = dt;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            mostarDatos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string eNombre = dataGridView1.SelectedRows[0].Cells["Nombre"].Value.ToString();
            string eUsuario = dataGridView1.SelectedRows[0].Cells["Usuario"].Value.ToString();
            string eClave = dataGridView1.SelectedRows[0].Cells["Clave"].Value.ToString();
            string eTipo = dataGridView1.SelectedRows[0].Cells["Tipo_Usr"].Value.ToString();

            txtnombre1.Text = eNombre;
            txtus.Text = eUsuario;
            txtcl.Text = eClave;
            txttipo.Text = eTipo;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            Conexcion con = new Conexcion();
            con.abrir();
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlCommand cmd = new SqlCommand("UPDATE Usuario SET Nombre='" + txtnombre1.Text + "',Usuario='" + txtus.Text + "',Clave='" + txtcl.Text + "',Tipo_Usr='" + txttipo.Text + "' where Id_usuario= @ID", con.sql);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.ExecuteNonQuery();
            con.close();

            txtnombre1.Text = "";
            txtus.Text = "";
            txtcl.Text = "";
            txttipo.Text = "";

            mostarDatos();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Conexcion con = new Conexcion();
            con.abrir();
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String sql = "DELETE FROM Usuario WHERE Id_usuario = @ID";
            SqlCommand cmd = new SqlCommand(sql, con.sql);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.ExecuteNonQuery();
            con.close();

            txtnombre1.Text = "";
            txtus.Text = "";
            txtcl.Text = "";
            txttipo.Text = "";


            mostarDatos();
        }
    }
}

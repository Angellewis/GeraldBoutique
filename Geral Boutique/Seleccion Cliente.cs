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
    public partial class Seleccion_Cliente : Form
    {
        public Seleccion_Cliente()
        {
            InitializeComponent();
        }
        public DataTable cargarclientes()
        {
            DataTable dt = new DataTable();
            Conexcion con = new Conexcion();
            string strSql = "Select * from Clientes";
            SqlDataAdapter da = new SqlDataAdapter(strSql, con.sql);
            da.Fill(dt);
            return dt;
        }

        private void Seleccion_Cliente_Load(object sender, EventArgs e)
        { 
            DataTable dt = cargarclientes();
            dgvbuscacli.DataSource = dt;
    }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            
            this.Close();

        }

        private void Seleccion_Cliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            AggFactura f = new AggFactura();
            string id, nombre, cedula, telefono, sector;
            try
            {
                id = dgvbuscacli.SelectedRows[0].Cells["Id_Clientes"].Value.ToString();
                cedula = dgvbuscacli.SelectedRows[0].Cells["Cedula"].Value.ToString();
                nombre = dgvbuscacli.SelectedRows[0].Cells["Nombre"].Value.ToString();
                telefono = dgvbuscacli.SelectedRows[0].Cells["Telefono"].Value.ToString();
                sector = dgvbuscacli.SelectedRows[0].Cells["Sector"].Value.ToString();
                f.txtuseractivo.Text = textBox1.Text;
                f.elid = id;
                f.elnombre = nombre;
                f.eltelefono = telefono;
                f.elsector = sector;
                f.Show();
            }
            catch (Exception u){
                MessageBox.Show("Debe Seleccionar un valor", "ERROR");
            }
        }

        private void txtbusqyeda_KeyUp(object sender, KeyEventArgs e)
        {
            
            Conexcion con = new Conexcion();
            con.abrir();
            string sql = "Select * from Clientes where Nombre like ('" + txtbusqyeda.Text + "%') and Cedula like ('" + textBox2.Text + "%')";
            SqlCommand cmd = new SqlCommand(sql, con.sql);
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvbuscacli.DataSource = dt;
            con.close();
        }
    }
}

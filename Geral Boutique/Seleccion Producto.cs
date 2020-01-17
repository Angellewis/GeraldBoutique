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
    public partial class Seleccion_Producto : Form
    {
        public Seleccion_Producto()
        {
            InitializeComponent();
            btnaceptar.DialogResult = DialogResult.OK;
        }

        public DataTable cargarproductos()
        {
            DataTable dt = new DataTable();
            Conexcion con = new Conexcion();
            string strSql = "Select * from Productos";
            SqlDataAdapter da = new SqlDataAdapter(strSql, con.sql);
            da.Fill(dt);
            return dt;
        }

        private void Seleccion_Producto_Load(object sender, EventArgs e)
        {
            DataTable dt = cargarproductos();
            dgvbuscarprod.DataSource = dt;
        }
    }
}

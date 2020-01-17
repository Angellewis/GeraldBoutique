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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            obtenerusuario();

        }
        public void obtenerusuario()
        {
            Conexcion con = new Conexcion();
            con.abrir();
            string corte = UserActivo.Text;
            string[] arreglo = corte.Split(':', ' ');
            string posicion = arreglo[3];
            String usuario = posicion;
            SqlCommand cmd = new SqlCommand("SELECT Nombre, Tipo_Usr FROM Usuario WHERE Usuario = @usuario", con.sql);
            cmd.Parameters.AddWithValue("usuario", usuario);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0][1].ToString() == "Admin" || dt.Rows[0][1].ToString() == "admin")
                {
                    panelClientes.Visible = false;
                    panelfacturas.Visible = false;
                    panelproductos.Visible = false;
                    panelusuarios.Visible = true;
                    con.close();

                }
                else if (dt.Rows[0][1].ToString() == "Usuario" || dt.Rows[0][1].ToString() == "usuario")
                {
                    MessageBox.Show("Usted No esta Autorizado para utilizar esta opcion", " Alerta");
                    panelusuarios.Visible = false;
                    con.close();
                }
            }
        }

        public void Obtenerusuario3()
        {
            Conexcion con = new Conexcion();
            con.abrir();
            string corte = UserActivo.Text;
            string[] arreglo = corte.Split(':', ' ');
            string posicion = arreglo[3];
            String usuario = posicion;
            SqlCommand cmd = new SqlCommand("SELECT Nombre, Tipo_Usr FROM Usuario WHERE Usuario = @usuario", con.sql);
            cmd.Parameters.AddWithValue("usuario", usuario);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0][1].ToString() == "Admin" || dt.Rows[0][1].ToString() == "admin")
                {
                    con.abrir();
                    string id = dgvfacturas.CurrentRow.Cells[0].Value.ToString();
                    String sql = "DELETE FROM Factura WHERE Codigo = @ID";
                    SqlCommand cmd2 = new SqlCommand(sql, con.sql);
                    cmd2.Parameters.Add(new SqlParameter("@ID", id));
                    cmd2.ExecuteNonQuery();
                    con.close();
                   // mostrarFacturas();
                }
                else if (dt.Rows[0][1].ToString() == "Usuario" || dt.Rows[0][1].ToString() == "usuario")
                {
                    MessageBox.Show("Usted No esta Autorizado para utilizar esta opcion", " Alerta");
                    con.close();
                }
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            Form3 fr = new Form3();
            fr.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelusuarios.Visible = false;
            panelClientes.Visible = false;
            panelfacturas.Visible = false;
            panelproductos.Visible = false;
        }

        public void button3_Click(object sender, EventArgs e)
        {
            panelusuarios.Visible = false;
            panelfacturas.Visible = false;
            panelproductos.Visible = false;
            panelClientes.Visible = true;
            mostarClientes();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmlogin fr = new frmlogin();
            fr.Show();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            panelClientes.Visible = false;
            panelusuarios.Visible = false;
            panelfacturas.Visible = false;
            panelproductos.Visible = true;
            mostrarProductos();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            panelClientes.Visible = false;
            panelusuarios.Visible = false;
            panelproductos.Visible = false;
            panelfacturas.Visible = true;
           // mostrarFacturas();
        }

        private void btnagrgprod_Click(object sender, EventArgs e)
        {
            AggProducto fr = new AggProducto();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                mostrarProductos();
            }
        }

        private void btncrearcli_Click(object sender, EventArgs e)
        {
            AggClientes f = new AggClientes();

            if (f.ShowDialog() == DialogResult.OK)
            {
                mostarClientes();
            }
        }

        private void btneditarcli_Click_1(object sender, EventArgs e)
        {try
            {
                EditClientes f = new EditClientes();
                string holis = UserActivo.Text;
                f.hola = holis;
                f.elid = dgvclientes.SelectedRows[0].Cells["Id_Clientes"].Value.ToString();
                f.elcedula = dgvclientes.SelectedRows[0].Cells["Cedula"].Value.ToString();
                f.elnombre = dgvclientes.SelectedRows[0].Cells["Nombre"].Value.ToString();
                f.eltelefono = dgvclientes.SelectedRows[0].Cells["Telefono"].Value.ToString();
                f.elsector = dgvclientes.SelectedRows[0].Cells["Sector"].Value.ToString();
                this.Hide();
                f.Show();
            } catch (Exception ex3) { MessageBox.Show("Debe Seleccionar un Cliente"); }
        }

        private void btnborrarcli_Click(object sender, EventArgs e)
        {try
            {
                Conexcion con = new Conexcion();
                con.abrir();
                string id = dgvclientes.CurrentRow.Cells[0].Value.ToString();
                String sql = "DELETE FROM Clientes WHERE Id_Clientes = @ID";
                SqlCommand cmd = new SqlCommand(sql, con.sql);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.ExecuteNonQuery();
                con.close();
                mostarClientes();
            } catch (Exception ex2) { MessageBox.Show("Debe Seleccionar un Cliente"); }
        }

        private void btnagrgfact_Click(object sender, EventArgs e)
        {

            AggFactura ag = new AggFactura();
            string corte = UserActivo.Text;
            string[] arreglo = corte.Split(':', ' ');
            string posicion = arreglo[3];
            string usuario = posicion;
            ag.txtuseractivo.Text = usuario;
            ag.Show();
        }

        private void btnbrrfact_Click(object sender, EventArgs e)
        {
            Obtenerusuario3();
        }

        private void btneditprod_Click(object sender, EventArgs e)
        {try
            {
                Editproductos CP = new Editproductos();
                string holis = UserActivo.Text;
                CP.hola = holis;
                CP.elid = dgvproductos.SelectedRows[0].Cells["Codigo"].Value.ToString();
                CP.elmarca = dgvproductos.SelectedRows[0].Cells["Marca"].Value.ToString();
                CP.elcategoria = dgvproductos.SelectedRows[0].Cells["Categoria"].Value.ToString();
                CP.eldescripcion = dgvproductos.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                CP.elpcosto = dgvproductos.SelectedRows[0].Cells["PCosto"].Value.ToString();
                CP.elpventa = dgvproductos.SelectedRows[0].Cells["PVenta"].Value.ToString();
                CP.elcantidad = dgvproductos.SelectedRows[0].Cells["Cantidad"].Value.ToString();
                this.Hide();
                CP.Show();
            }
            catch (Exception ex) { MessageBox.Show("Debe Seleccionar un Producto"); }
        }

        private void btnbrrprod_Click(object sender, EventArgs e)
        {
            try
            {
                Conexcion con = new Conexcion();
                con.abrir();
                string id = dgvproductos.CurrentRow.Cells[0].Value.ToString();
                String sql = "DELETE FROM Productos WHERE Codigo = @ID";
                SqlCommand cmd = new SqlCommand(sql, con.sql);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.ExecuteNonQuery();
                con.close();
                mostrarProductos();
            }
            catch (Exception ex1) { MessageBox.Show("Debe Seleccionar un Producto"); }
        }

        private void btnregistar_Click(object sender, EventArgs e)
        {
            if (txtcontrasena.Text == txtconfircontra.Text)
            {
                if (txtnombreusr.Text == "" || txtusuarioprc.Text == "" || txtcontrasena.Text == "" || txttipousr.Text == "")
                {
                    MessageBox.Show("Por Favor Introduzca sus Datos completos", "Aviso!");
                }

                else if (NuevoUsuario.Crearcuentas(txtnombreusr.Text, txtusuarioprc.Text, txtcontrasena.Text, txttipousr.Text) > 0)
                {

                    MessageBox.Show("Cuenta creada con exito.");
                    txtnombreusr.Text = "";
                    txtusuarioprc.Text = "";
                    txtcontrasena.Text = "";
                    txtconfircontra.Text = "";
                    txttipousr.Text = "";
                }
            }
            else
            {
                MessageBox.Show("No se pudo crear la cuenta.");
            }
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

        public DataTable cargarproductos()
        {
            DataTable dt = new DataTable();
            Conexcion con = new Conexcion();
            string strSql = "Select * from Productos";
            SqlDataAdapter da = new SqlDataAdapter(strSql, con.sql);
            da.Fill(dt);
            return dt;
        }

       /* public DataTable cargarfacturas()
        {
            DataTable dt = new DataTable();
            Conexcion con = new Conexcion();
            string strSql = "Select * from Detalle";
            SqlDataAdapter da = new SqlDataAdapter(strSql, con.sql);
            da.Fill(dt);
            return dt;
        }

        public void mostrarFacturas()
        {
            DataTable dt = cargarfacturas();
            dgvfacturas.DataSource = dt;
        } */

        public void mostrarProductos()
        {
            DataTable dt = cargarproductos();
            dgvproductos.DataSource = dt;
        }
        public void mostarClientes()
        {
            DataTable dt = cargarclientes();
            dgvclientes.DataSource = dt;
        }

        private void txtbusnombre_KeyUp(object sender, KeyEventArgs e)
        {
            Conexcion con = new Conexcion();
            con.abrir();
            string sql = "Select * from Clientes where Nombre like ('" + txtbusnombre.Text + "%') and Cedula like ('" + txtbuscedula.Text + "%')";
            SqlCommand cmd = new SqlCommand(sql, con.sql);
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvclientes.DataSource = dt;
            con.close();
        }

        private void txtdesc_KeyUp(object sender, KeyEventArgs e)
        {
            Conexcion con = new Conexcion();
            con.abrir();
            string sql = "Select * from Productos where Descripcion like ('" + txtdesc.Text + "%') and Categoria like ('" + txtmarca.Text + "%')";
            SqlCommand cmd = new SqlCommand(sql, con.sql);
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvproductos.DataSource = dt;
            con.close();
        }

        private void txtmarca_TextChanged(object sender, EventArgs e)
        {
            Conexcion con = new Conexcion();
            con.abrir();
            string sql = "Select * from Productos where Descripcion like ('" + txtdesc.Text + "%') and Categoria like ('" + txtmarca.Text + "%')";
            SqlCommand cmd = new SqlCommand(sql, con.sql);
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvproductos.DataSource = dt;
            con.close();
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            Conexcion con = new Conexcion();
            con.abrir();
            string sql = "Select * from Factura where Codigo like ('" + textBox5.Text + "%') and Cliente like ('" + textBox4.Text + "%')";
            SqlCommand cmd = new SqlCommand(sql, con.sql);
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvfacturas.DataSource = dt;
            con.close();
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
           // mostrarFacturas();
        }
    }
    }

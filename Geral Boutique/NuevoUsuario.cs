using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Geral_Boutique
{
    class NuevoUsuario
    {
        public static int Crearcuentas(string pnombre, string pUsuario, string pConstrasena, string ptipousr)
        {
            Conexcion con = new Conexcion();
            int resultado = 1;
            con.abrir();
            string Codigo = "";
            int total = 0;
            try
            {
                SqlCommand sqd = new SqlCommand("Select count(*) as totalRegistros from Usuario", con.sql);
                int hola = Convert.ToInt32(sqd.ExecuteScalar());
                total = hola;

                if (total < 10)
                {
                    Codigo = "GS-000" + total.ToString();
                }
                else if (total < 100)
                {
                    Codigo = "GS-00" + total.ToString();
                }
                else if (total < 1000)
                {
                    Codigo = "GS-0" + total.ToString();
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error al crear el Codigo" + e.ToString());
            }
            string sql = "insert into Usuario(Id_usuario, Nombre, Usuario, Clave, Tipo_Usr) values " +
                "(@Id_usuario, @Nombre, @Usuario, @Clave, @Tipo_Usr)";
            SqlCommand cmd = new SqlCommand(sql, con.sql);
            cmd.Parameters.Add(new SqlParameter("@Id_usuario", Codigo));
            cmd.Parameters.Add(new SqlParameter("@Nombre",pnombre ));
            cmd.Parameters.Add(new SqlParameter("@Usuario", pUsuario ));
            cmd.Parameters.Add(new SqlParameter("@Clave", pConstrasena ));
            cmd.Parameters.Add(new SqlParameter("@Tipo_Usr", ptipousr));
            cmd.ExecuteNonQuery();
            con.close();
            return resultado;
        }

        public static int CrearCliente(string pcedula, string pnombre, string ptelefono, string psector)
        {
            Conexcion con = new Conexcion();
            con.abrir();
            int resultado = 1;
            con.abrir();
            string Codigo = "";
            int total = 0;
            try
            {
                SqlCommand sqd = new SqlCommand("Select count(*) as totalRegistros from Clientes", con.sql);
                int hola = Convert.ToInt32(sqd.ExecuteScalar());
                total = hola;

                if (total < 10)
                {
                    Codigo = "CL-000" + total.ToString();
                }
                else if (total < 100)
                {
                    Codigo = "CL-00" + total.ToString();
                }
                else if (total < 1000)
                {
                    Codigo = "CL-0" + total.ToString();
                }
            }
            catch (Exception a)
            {
                System.Windows.Forms.MessageBox.Show("Error al crear el Codigo" + a.ToString());
            }
            string sql = "insert into Clientes(Id_Clientes, Cedula, Nombre, Telefono, Sector) values " +
                "(@Id_Clientes,@Cedula, @Nombre, @Telefono, @Sector)";
            SqlCommand cmd = new SqlCommand(sql, con.sql);
            cmd.Parameters.Add(new SqlParameter("@Id_Clientes", Codigo));
            cmd.Parameters.Add(new SqlParameter("@Cedula", pcedula));
            cmd.Parameters.Add(new SqlParameter("@Nombre", pnombre));
            cmd.Parameters.Add(new SqlParameter("@Telefono", ptelefono));
            cmd.Parameters.Add(new SqlParameter("@Sector", psector));
            cmd.ExecuteNonQuery();
            con.close();
            return resultado;          
        }

        public static int CrearProducto(string pdescripcion, string pmarca, string pcategoria, string pcosto, string pventa, int pcantidad)
        {
            Conexcion con = new Conexcion();
            con.abrir();
            int resultado = 1;
            con.abrir();
            string Codigo = "";
            int total = 0;
            try
            {
                SqlCommand sqd = new SqlCommand("Select count(*) as totalRegistros from Productos", con.sql);
                int hola = Convert.ToInt32(sqd.ExecuteScalar());
                total = hola;

                if (total < 10)
                {
                    Codigo = "PD-000" + total.ToString();
                }
                else if (total < 100)
                {
                    Codigo = "PD-00" + total.ToString();
                }
                else if (total < 1000)
                {
                    Codigo = "PD-0" + total.ToString();
                }
            }
            catch (Exception a)
            {
                System.Windows.Forms.MessageBox.Show("Error al crear el Codigo" + a.ToString());
            }
            string sql = "insert into Productos(Codigo, Descripcion, Marca, Categoria, PCosto, PVenta, Cantidad) values " +
                "(@Codigo,@Descripcion, @Marca, @Categoria, @PCosto, @PVenta, @Cantidad)";
            SqlCommand cmd = new SqlCommand(sql, con.sql);
            cmd.Parameters.Add(new SqlParameter("@Codigo", Codigo));
            cmd.Parameters.Add(new SqlParameter("@Descripcion", pdescripcion));
            cmd.Parameters.Add(new SqlParameter("@Marca", pmarca));
            cmd.Parameters.Add(new SqlParameter("@Categoria", pcategoria));
            cmd.Parameters.Add(new SqlParameter("@PCosto", pcosto));
            cmd.Parameters.Add(new SqlParameter("@PVenta", pventa));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", pcantidad));
            cmd.ExecuteNonQuery();
            con.close();
            return resultado;
        }

        public static DataSet Ejecutar(string cmd)
        {
            Conexcion con = new Conexcion();
            con.abrir();

            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd, con.sql);

            DP.Fill(DS);
            con.close();

            return DS;
        }

        public static int CrearFactura(string codigofactura, string fecha, string usuario, string cliente, string cedula, string productos, float total, string observacion)
        {
            Conexcion con = new Conexcion();
            con.abrir();
            int resultado = 1;
            string sql = "insert into Factura(Codigo, Fecha, Usuario, Cliente, CedulaCliente, Productos, Total, Observacion) values " +
                "(@Codigo,@Fecha, @Usuario, @Cliente, @CedulaCliente, @Productos, @Total, @Observacion)";
            SqlCommand cmd = new SqlCommand(sql, con.sql);
            cmd.Parameters.Add(new SqlParameter("@Codigo", codigofactura));
            cmd.Parameters.Add(new SqlParameter("@Fecha", fecha));
            cmd.Parameters.Add(new SqlParameter("@Usuario", usuario));
            cmd.Parameters.Add(new SqlParameter("@Cliente", cliente));
            cmd.Parameters.Add(new SqlParameter("@CedulaCliente", cedula));
            cmd.Parameters.Add(new SqlParameter("@Productos", productos));
            cmd.Parameters.Add(new SqlParameter("@Total", total));
            cmd.Parameters.Add(new SqlParameter("@Observacion", observacion));
            cmd.ExecuteNonQuery();
            con.close();
            return resultado;
        }
    }
}

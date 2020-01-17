using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geral_Boutique
{
    class Conexcion
    {
        String connect = "Data Source=ANGEL\\ANGELSQL;Initial Catalog=Facturacion; Integrated Security=true";
        public SqlConnection sql = new SqlConnection();

        public Conexcion()
        {
            sql.ConnectionString = connect;
        }
        public void abrir()
        {
            try
            {
                sql.Open();
                Console.WriteLine("Conexcion Exitosa");
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
        public void close()
        {
            sql.Close();
        }
    }
}

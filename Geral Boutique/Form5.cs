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
    public partial class AggClientes : Form
    {
        public AggClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (txtcedulacli.Text == "" || txtnombrecli.Text == "" || txtsectorcli.Text == "" || txttelcli.Text == "")
                {
                    MessageBox.Show("Por Favor Introduzca Los Datos completos", "Aviso!");
                }

                else if (NuevoUsuario.CrearCliente(txtcedulacli.Text, txtnombrecli.Text, txttelcli.Text, txtsectorcli.Text) > 0)
                {

                    MessageBox.Show("Cliente agregado con exito", "Notificacion");
                    txtcedulacli.Text = "";
                    txtnombrecli.Text = "";
                    txtsectorcli.Text = "";
                    txttelcli.Text = "";
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se pudo crear la cuenta.");
            }
        }
    }
}

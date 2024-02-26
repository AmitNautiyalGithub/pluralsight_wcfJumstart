using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zza.Client.ZzaService;

namespace Zza.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ZzaServiceClient client = new ZzaServiceClient("NetTcpBinding_IZzaService");

            ZzaProxy proxy = new ZzaProxy("NetTcpBinding_IZzaService");
            proxy.ClientCredentials.Windows.ClientCredential.UserName = "";

            try
            {
                //var result = client.GetCustomers();
                var customer = proxy.GetCustomers();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               // client.Close();

            }

        }
    }
}

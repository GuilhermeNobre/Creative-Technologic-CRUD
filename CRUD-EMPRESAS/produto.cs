using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD_EMPRESAS
{
    public partial class produto : Form
    {

        //Conexão via string
        string path = "Data Source=DESKTOP-DTKBJB1;Initial Catalog=registration;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        System.Data.DataTable dt;


        public produto()
        {
            InitializeComponent();
        }

        private void produto_Load(object sender, EventArgs e)
        {

        }
    }
}

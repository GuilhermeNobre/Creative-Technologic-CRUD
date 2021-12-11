using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD_EMPRESAS
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DTKBJB1;Initial Catalog=registration;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUName.Text=="" && txtPssd.Text=="")
                {
                    MessageBox.Show("Por Favor preencha os campos obrigatórios");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select * from LoginUsers where U_name=@Name and U_Pass=@Pass", conn);
                    cmd.Parameters.Add("@Name", txtUName.Text);
                    cmd.Parameters.Add("@Pass", txtPssd.Text);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);

                    int count = ds.Tables[0].Rows.Count;

                    if(count == 1)
                    {
                        MessageBox.Show("Logado com sucesso");
                        Form1 ob = new Form1();
                        this.Hide();
                        ob.Show();

                    }
                    else
                    {
                        MessageBox.Show("Por favor entre com usuário e senha");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //SqlConnection conn = null;
        }
    }
}

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
    public partial class fatura : Form
    {

        //Conexão via string
        string path = "Data Source=DESKTOP-DTKBJB1;Initial Catalog=registration;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int month_id;


        public fatura()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtValue.Text == "")
            {
                MessageBox.Show("Favor Inisira todos os dados");
            }
            else
            {
                try
                {
                    con.Open();

                    cmd = new SqlCommand("insert into Fature (name_month, value_number) values ('" + txtName.Text + "', '" + txtValue.Text + "')", con);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Valor adicionado");
                    //cmd = new SqlCommand("insert into Employee (Employee_Name, Employee_FName ,Employee_Designation ,Employee_Email ,Emp_ID ,Gender, Addrss) " +
                    //"values ('" + txtName.Text + "' , '" + txtFName.Text + "', '" + txtFunction.Text + "' , '" + txtEmail.Text + "', '" + txtID.Text + "', '" + gender + "', '" + txtAddress.Text + "')", con);
                    con.Close();
                    display();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            month_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtValue.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        public void clear()
        {
            txtName.Text = "";
            txtValue.Text = "";
        }

        public void display()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from Fature", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fatura_Load(object sender, EventArgs e)
        {

        }


    }
}

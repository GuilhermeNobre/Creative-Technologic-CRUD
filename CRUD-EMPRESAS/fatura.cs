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
using Microsoft.Office.Interop.Excel;

namespace CRUD_EMPRESAS
{
    public partial class fatura : Form
    {

        //Conexão via string
        string path = "Data Source=DESKTOP-DTKBJB1;Initial Catalog=registration;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        System.Data.DataTable dt;
        int month_id;



        public fatura()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
            button2.Enabled = false;
            button3.Enabled = false;
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
                dt = new System.Data.DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from Fature", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) //adicionar 
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

        private void fatura_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Editar
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("update Fature set name_month='" + txtName.Text + "', value_number= '" + txtValue.Text + "' where month_id='" + month_id + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Dados atualizados ");
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            month_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtValue.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e) // Excluir 
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from Fature where month_id='" + month_id + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Dado deletado da lista");
                display();

            }
            catch (Exception ex)
            {

            }

        }

        private void button4_Click(object sender, EventArgs e) // Export Excell
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application Excell = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = Excell.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet ws = (Worksheet)Excell.ActiveSheet;
                Excell.Visible = true;

                for (int j = 2; j <= dataGridView1.Rows.Count; j++)
                {
                    for (int i = 1; i <= 1; i++)
                    {
                        ws.Cells[j, i] = dataGridView1.Rows[j - 2].Cells[i - 1].Value;
                    }
                }

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    ws.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            catch (Exception)
            {

            }


        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from Fature where name_month like '%" + searchBar.Text + "%' ", con);
            dt = new System.Data.DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from Fature where value_number like '%" + searchBar.Text + "%' ", con);
            dt = new System.Data.DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

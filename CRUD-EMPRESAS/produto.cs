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
using Microsoft.Office.Interop.Excel;

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
        int Id;

        public produto()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void clear()
        {
            txtName.Text = "";
        }

        public void display()
        {
            try
            {
                dt = new System.Data.DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from products", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void produto_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string typeprod;
            if (rbtA.Checked)
            {
                typeprod = "TIPO A";
            }
            else if (rbtB.Checked)
            {
                typeprod = "TIPO B";
            }
            else if(rbtC.Checked)
            {
                typeprod = "TIPO C";
            }
            else if(rbtD.Checked)
            {
                typeprod = "TIPO D";
            }
            else
            {
                typeprod = null;
            }


            if (txtName.Text == "")
            {
                MessageBox.Show("Favor Insirida todos os dados");

            }
            else
            {
                try
                {

                    con.Open();
                    cmd = new SqlCommand("insert into products (name_product, type_product) values ('" + txtName.Text + "', '" + typeprod + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(" Dados enviados para o banco de dados ");
                    clear();
                    display();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        } // Add

        private void button2_Click(object sender, EventArgs e) // Update
        {
            try
            {
                string typeprod;
                if (rbtA.Checked)
                {
                    typeprod = "TIPO A";
                }
                else if (rbtB.Checked)
                {
                    typeprod = "TIPO B";
                }
                else if (rbtC.Checked)
                {
                    typeprod = "TIPO C";
                }
                else if (rbtD.Checked)
                {
                    typeprod = "TIPO D";
                }
                else
                {
                    typeprod = null;
                }

                con.Open();
                cmd = new SqlCommand("update products set name_product='" + txtName.Text + "', type_product='" + typeprod + "' where product_Id='" + Id + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Dados atualizados ");
                display();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            rbtA.Checked = true;
            rbtB.Checked = false;
            rbtC.Checked = false;
            rbtD.Checked = false;

            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "TIPO B")
            {
                rbtA.Checked = false;
                rbtB.Checked = true;
                rbtC.Checked = false;
                rbtD.Checked = false;
            }

            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "TIPO C")
            {
                rbtA.Checked = false;
                rbtB.Checked = false;
                rbtC.Checked = true;
                rbtD.Checked = false;
            }

            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "TIPO D")
            {
                rbtA.Checked = false;
                rbtB.Checked = false;
                rbtC.Checked = false;
                rbtD.Checked = true;
            }

            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from products where product_Id='" + Id + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Dado deletado da lista");
                display();

            }
            catch (Exception ex)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from products where type_product like '%" + searchBar.Text + "%' ", con);
            dt = new System.Data.DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

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
    public partial class Reports : Form
    {
        //Conexão via string
        string path = "Data Source=DESKTOP-DTKBJB1;Initial Catalog=registration;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int report_id;


        public Reports()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {   
                con.Open();
                cmd = new SqlCommand("insert into reports (name_report, obs_report) values ('"+ txtName.Text + "', '"+ txtObs.Text +"')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Dados enviados para o banco de dados ");
                con.Close();
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Update
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("update reports set name_report='" + txtName.Text + "', obs_report= '" + txtObs.Text + "' where report_id='" + report_id + "' ", con);
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

        private void button3_Click(object sender, EventArgs e) //Delete
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from reports where report_id='" + report_id + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Dado deletado da lista");
                display();

            }
            catch (Exception ex)
            {

            }
        }




        public void display()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from reports", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            report_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtObs.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from reports where name_report like '%" + searchBar.Text + "%' ", con);
            dt = new System.Data.DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}

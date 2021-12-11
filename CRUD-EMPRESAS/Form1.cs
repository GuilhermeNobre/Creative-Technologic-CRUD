using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EMPRESAS
{
    public partial class Form1 : Form
    {
        Registro rg = new Registro();  
        fatura fatura = new fatura(); 
        produto produto = new produto(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rg.Show();  
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Login obje = new Login();
           obje.Show();
           this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fatura.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            produto.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string target = "http://127.0.0.1:5500/index.html";
            //Use no more than one assignment when you test this code.
            //string target = "ftp://ftp.microsoft.com";
            //string target = "C:\\Program Files\\Microsoft Visual Studio\\INSTALL.HTM";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

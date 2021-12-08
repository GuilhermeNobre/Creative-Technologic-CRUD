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
    }
}

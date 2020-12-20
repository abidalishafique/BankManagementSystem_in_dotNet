using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Management_System
{
    public partial class account_balan : Form
    {
        string aa = "",bb = "";
        public account_balan(string a,string b)
        {
            InitializeComponent();
            aa = a;
            bb = b;
        }

        private void last_name_TextChanged(object sender, EventArgs e)
        {




        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void first_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void account_balan_Load(object sender, EventArgs e)
        {
            first_name.Text = aa;
            last_name.Text = bb;

        }
    }
}

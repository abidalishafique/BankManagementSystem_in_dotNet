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
    public partial class account_number : Form
    {
        string aa = "", bb = "";
        public account_number(string a,string b)
        {
            InitializeComponent();
            aa = a;
            bb = b;
        }

        private void account_number_Load(object sender, EventArgs e)
        {
            first_name.Text = aa;
            last_name.Text = bb;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

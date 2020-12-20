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
    public partial class Select : Form
    {
        public Select()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Select_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_login a = new Admin_login();
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Employee_login a = new Employee_login();
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            User_login a = new User_login();
            a.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome w = new Welcome();
            w.ShowDialog();
        }

        private void button5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 8)
            {
                this.Hide();
                Welcome w = new Welcome();
                w.ShowDialog();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            this.Hide();
            Welcome f = new Welcome();
            f.ShowDialog();
        }
    }
}

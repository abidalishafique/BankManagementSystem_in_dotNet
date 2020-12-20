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
    public partial class User_Option : Form
    {
        string ss = "";
        public User_Option(string val)
        {
            InitializeComponent();
            label1.Text = label1.Text + val + ".....";
            ss = val;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_login u = new User_login();
            u.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void User_Option_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_change_password p = new User_change_password(ss);
            p.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Detail u = new User_Detail(ss);
            u.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f = new Welcome();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Deposit u = new User_Deposit(ss);
            u.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_withdraw w = new User_withdraw(ss);
            w.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            check_balance b = new check_balance(ss);
            b.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            transfer t = new transfer(ss);
            t.ShowDialog();
        }
    }
}

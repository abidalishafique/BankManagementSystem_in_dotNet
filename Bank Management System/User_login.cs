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

namespace Bank_Management_System
{
    public partial class User_login : Form
    {
        public User_login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Select s = new Select();
            s.ShowDialog();
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                this.Hide();
                Welcome w = new Welcome();
                w.ShowDialog();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                if (textBox1.Text == "")
                {
                    label1.Text = "Please Fill this!";
                }
                if (textBox2.Text == "")
                {
                    label5.Text = "Please Fill this!";
                }
                MessageBox.Show("Please Fill the Following DATA!");
            }
            else
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Abid Shafique\documents\visual studio 2013\Projects\Bank Management System\Bank Management System\Bank.mdf;Integrated Security=True");
                sqlcon.Open();
                string query = "Select * from user_login where user_name= '"+textBox1.Text.Trim() + "' and passward = '" + textBox2.Text.Trim()+"';";
                SqlDataAdapter sda = new SqlDataAdapter(query,sqlcon);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if(dtable.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid/Incorrect User Name or Password!");
                }
                else
                {
                    this.Hide();
                    User_Option u = new User_Option(textBox1.Text);
                    u.ShowDialog();
                    
                }
                sqlcon.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void User_login_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f = new Welcome();
            f.ShowDialog();
        }
    }
}

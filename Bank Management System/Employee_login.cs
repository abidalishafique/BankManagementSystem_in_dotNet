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
    public partial class Employee_login : Form
    {
        public Employee_login()
        {
            InitializeComponent();
        }
        private void Employee_login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Select s = new Select();
            s.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f = new Welcome();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
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
                string query = "Select * from emp_login where login_name= '" + textBox1.Text.Trim() + "' and password = '" + textBox2.Text.Trim() + "';";
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                SqlDataReader rd = cmd.ExecuteReader();
                string str = "";
                if(rd.HasRows)
                {
                    while(rd.Read())
                    {
                        str = rd[7].ToString();
                    }
                    if(str == "cashier1")
                    {
                        this.Hide();
                        cashier1 c = new cashier1(textBox1.Text);
                        c.ShowDialog();
                    }
                    else if(str == "cashier2")
                    {
                        this.Hide();
                        cashier2 c = new cashier2(textBox1.Text);
                        c.ShowDialog();
                    }
                    else if (str == "accountant")
                    {
                        this.Hide();
                        accountant c = new accountant(textBox1.Text);
                        c.ShowDialog();
                    }
                    else if (str == "Data Modifier")
                    {
                        this.Hide();
                        Data_Modifier c = new Data_Modifier(textBox1.Text);
                        c.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No Job exits for this Login...!");
                    }
                }
                else
                {
                    MessageBox.Show("Entered Employee_name/password is incorrect....!");
                }
                sqlcon.Close();
            }
        }
    }
}

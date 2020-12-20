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
    public partial class cashier2_withdraw : Form
    {
        string ss = "";
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Abid Shafique\documents\visual studio 2013\Projects\Bank Management System\Bank Management System\Bank.mdf;Integrated Security=True");
       
        public cashier2_withdraw(string s)
        {
            InitializeComponent();
            label1.Text = label1.Text + s + ".....";
            ss = s;
        }

        public bool check_amount(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public string trimspcaces(string s)
        {
            int length = s.Length - 1;
            while (length > 0)
            {
                if (s[length] != ' ')
                {
                    break;
                }
                length--;
            }
            string bb = s.Substring(0, length + 1);
            return bb;
        }
        private void cashier2_withdraw_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome w = new Welcome();
            w.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            label3.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label7.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            cashier2 u = new cashier2(ss);
            u.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "" || textBox3.Text == "")
            {
                if (textBox2.Text == "")
                {
                    label5.Text = "Please Fill this!";
                }
                if (textBox1.Text == "")
                {
                    label3.Text = "Please Fill this!";
                }
                if (textBox3.Text == "")
                {
                    label7.Text = "Please Fill this!";
                }
                MessageBox.Show("Please Fill the Following DATA!");
            }
            else
            {
                sqlcon.Open();
                string query = "select * from emp_login where login_name= '" + ss + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                SqlDataReader dr = cmd.ExecuteReader();
                string pass = "";
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pass = dr[2].ToString();
                    }
                }
                pass = trimspcaces(pass);
                sqlcon.Close();
                if (textBox2.Text != pass)
                {
                    MessageBox.Show("Your Password is Incorrect please Enter correct Passward!...");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    if (check_amount(textBox1.Text))
                    {
                        if (double.Parse(textBox1.Text) >= 500)
                        {
                            if(check_amount(textBox3.Text) && textBox3.Text.Length > 9)
                            {
                                string accc = textBox3.Text.Substring(9);
                                sqlcon.Open();
                                SqlCommand cmd1 = sqlcon.CreateCommand();
                                cmd1.CommandType = CommandType.Text;
                                cmd1.CommandText = "select Balance from account where account_number = "+accc;
                                cmd1.ExecuteNonQuery();
                                SqlDataReader dr1 = cmd1.ExecuteReader();
                                double b = 0;
                                if (dr1.HasRows)
                                {
                                    while (dr1.Read())
                                    {
                                        b = double.Parse(dr1[0].ToString());
                                    }
                                    sqlcon.Close();

                                    if (b >= double.Parse(textBox1.Text))
                                    {
                                        b = b - double.Parse(textBox1.Text);
                                        string k = "update account set Balance = " + b.ToString() + " where account_number = "+accc;
                                        sqlcon.Open();
                                        SqlCommand cm = sqlcon.CreateCommand();
                                        cm.CommandType = CommandType.Text;
                                        cm.CommandText = k;
                                        cm.ExecuteNonQuery();
                                        sqlcon.Close();
                                        MessageBox.Show("Money/Amount withdraw from account Successfully!");
                                        this.Hide();
                                        cashier2 u = new cashier2(ss);
                                        u.ShowDialog();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Account's balance is less than your enterd Amount..");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Entered Account Number does not exist......!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("You entered an invalid Account Number.....!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Amount/MMoney must be greater than or equal 500!...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You enter an invalid amount please enter amount correctly!...");
                    }
                }
            }
        }
    }
}

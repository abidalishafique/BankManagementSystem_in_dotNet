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
    public partial class User_withdraw : Form
    {
        string ss = "";
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Abid Shafique\documents\visual studio 2013\Projects\Bank Management System\Bank Management System\Bank.mdf;Integrated Security=True");
        public User_withdraw(string s)
        {
            InitializeComponent();
            label1.Text = label1.Text + s + ".....";
            ss = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void User_withdraw_Load(object sender, EventArgs e)
        {
            sqlcon.Open();
            SqlCommand cmd1 = sqlcon.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select account_number from account,user_login where user_name='" + ss + "' and account.User_id = user_login.user_id";
            cmd1.ExecuteNonQuery();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    textBox3.Text = "000099999" + dr1[0].ToString();
                }
            }
            sqlcon.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f = new Welcome();
            f.ShowDialog();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Option u = new User_Option(ss);
            u.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text=="" || textBox1.Text=="")
            {
                if(textBox2.Text=="")
                {
                    label5.Text = "Please Fill this!";
                }
                if (textBox1.Text == "")
                {
                    label3.Text = "Please Fill this!";
                }
                MessageBox.Show("Please Fill the Following DATA!");
            }
            else
            {
                sqlcon.Open();
                string query = "select * from user_login where user_name= '" + ss + "'";
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
                else
                {
                    MessageBox.Show(ss);
                }
                pass = trimspcaces(pass);
                sqlcon.Close();
                if (textBox2.Text != pass)
                {
                    MessageBox.Show("Your Password is Incorrect please Enter correct Passward!...");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    if(check_amount(textBox1.Text))
                    {
                        if(double.Parse(textBox1.Text) >=500)
                        {
                            sqlcon.Open();
                            SqlCommand cmd1 = sqlcon.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "select account.User_id,Balance from account,user_login where user_name='"+ss+"' and account.User_id = user_login.user_id";
                            cmd1.ExecuteNonQuery();
                            SqlDataReader dr1 = cmd1.ExecuteReader();
                            double b = 0;
                            int a = 0;
                            if (dr1.HasRows)
                            {
                                while (dr1.Read())
                                {
                                    a = int.Parse(dr1[0].ToString());
                                    b = double.Parse(dr1[1].ToString());
                                }
                            }
                            sqlcon.Close();
                            if (b >= double.Parse(textBox1.Text))
                            {
                                b = b - double.Parse(textBox1.Text);
                                string k = "update account set Balance = " + b.ToString() + " where User_id = " + a.ToString();
                                sqlcon.Open();
                                SqlCommand cm = sqlcon.CreateCommand();
                                cm.CommandType = CommandType.Text;
                                cm.CommandText = k;
                                cm.ExecuteNonQuery();
                                sqlcon.Close();
                                MessageBox.Show("Money/Amount withdraw from your account Successfully!");
                                this.Hide();
                                User_Option u = new User_Option(ss);
                                u.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Your account balance is less than your enterd Amount..");
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
    }
}

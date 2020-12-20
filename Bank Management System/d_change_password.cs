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
    public partial class d_change_password : Form
    {
        string ss = "";
        public d_change_password(string s)
        {
            InitializeComponent();
            label1.Text = label1.Text + s + ".....";
            ss = s;
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
        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome w = new Welcome();
            w.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Data_Modifier d = new Data_Modifier(ss);
            d.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                if (textBox1.Text == "")
                {
                    label3.Text = "Please Fill this!";
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
                    if (textBox1.Text.Length > 9)
                    {
                        string aacc = textBox1.Text.Substring(9);
                        sqlcon.Open();
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = sqlcon;
                        cmd1.CommandText = "select * from account where account_number = '" + aacc + "'";
                        cmd1.ExecuteNonQuery();

                        SqlDataReader dr1 = cmd1.ExecuteReader();
                        double balance = 0;
                        int id = 0;
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                id = int.Parse(dr1[1].ToString());
                                balance = double.Parse(dr1[2].ToString());
                            }
                            sqlcon.Close();
                            sqlcon.Open();
                            SqlCommand cmd2 = new SqlCommand();
                            cmd2.Connection = sqlcon;
                            cmd2.CommandText = "update user_login set passward = 'punjab' where user_id = "+id.ToString();
                            cmd2.ExecuteNonQuery();
                            sqlcon.Close();
                            MessageBox.Show("Passwaor Change and new password is 'punjab'. Told the user to chnage asa soon as possible!");
                            this.Hide();
                            Data_Modifier dd = new Data_Modifier(ss);
                            dd.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Account Number doesn't exist........!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Account Number doesn't exist........!");
                    }
                }
            }
        }

        private void d_change_password_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class cashier1_deposit_cheque : Form
    {
        string ss = "";
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Abid Shafique\documents\visual studio 2013\Projects\Bank Management System\Bank Management System\Bank.mdf;Integrated Security=True");
        
        public cashier1_deposit_cheque(string s)
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
        public bool check(string s)
        {
            if (s.Substring(0, 9) == "000099999")
                return true;
            return false;
        }
        private void cashier1_deposit_cheque_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            cashier1 c = new cashier1(ss);
            c.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome w = new Welcome();
            w.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label10.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label7.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox3.Text == "")
            {
                if (textBox1.Text == "")
                {
                    label3.Text = "Please Fill this!";
                }
                if (textBox2.Text == "")
                {
                    label5.Text = "Please Fill this!";
                }
                if (textBox4.Text == "")
                {
                    label7.Text = "Please Fill this!";
                }
                if (textBox3.Text == "")
                {
                    label10.Text = "Please Fill this!";
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
                }
                else
                {
                    if (check_amount(textBox4.Text))
                    {
                        if (double.Parse(textBox4.Text) >= 500)
                        {
                            if ((check_amount(textBox1.Text) && check_amount(textBox3.Text) )&& (textBox3.Text.Length>9 && textBox1.Text.Length > 9))
                            {
                                string acco = textBox3.Text.Substring(9);
                                sqlcon.Open();
                                SqlCommand cmd1 = sqlcon.CreateCommand();
                                cmd1.CommandType = CommandType.Text;
                                cmd1.CommandText = "select Balance from account where account_number="+acco;
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
                                    if (b >= double.Parse(textBox4.Text))
                                    {
                                        if (check(textBox1.Text))
                                        {
                                            string sub = textBox1.Text.Substring(9);
                                            int acc = int.Parse(sub);
                                            sqlcon.Open();
                                            SqlCommand c1 = sqlcon.CreateCommand();
                                            c1.CommandType = CommandType.Text;
                                            c1.CommandText = "select Balance from account where account_number = " + acc.ToString();
                                            c1.ExecuteNonQuery();
                                            SqlDataReader drr1 = c1.ExecuteReader();
                                            double bb = 0;
                                            if (drr1.HasRows)
                                            {
                                                while (drr1.Read())
                                                {
                                                    bb = double.Parse(drr1[0].ToString());
                                                }
                                                sqlcon.Close();
                                                bb = bb + double.Parse(textBox4.Text);
                                                string k = "update account set Balance = " + bb.ToString() + " where account_number = " + acc.ToString();
                                                sqlcon.Open();
                                                SqlCommand cm = sqlcon.CreateCommand();
                                                cm.CommandType = CommandType.Text;
                                                cm.CommandText = k;
                                                cm.ExecuteNonQuery();
                                                sqlcon.Close();

                                                b = b - double.Parse(textBox4.Text);
                                                string kk = "update account set Balance = " + b.ToString() + " where account_number = " + acco;
                                                sqlcon.Open();
                                                SqlCommand cm1 = sqlcon.CreateCommand();
                                                cm1.CommandType = CommandType.Text;
                                                cm1.CommandText = kk;
                                                cm1.ExecuteNonQuery();
                                                sqlcon.Close();
                                                MessageBox.Show("Money transfer Successfully!");
                                                this.Hide();
                                                cashier1 u = new cashier1(ss);
                                                u.ShowDialog();

                                            }
                                            else
                                            {
                                                MessageBox.Show("Entered TO Account Number Does not exist...");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Your Entered TO Account Number does not exists..");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("From account balance is less than your enterd Amount..");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("From Account Number does not exites!...");
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Enter Account Number is not Valid!...");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Amount/MMoney must be greater than or equal 500!...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Entered Ammount is Invalid...");
                    }
                }
            }
        }
    }
}

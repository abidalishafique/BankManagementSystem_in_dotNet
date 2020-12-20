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
    public partial class Admin_change_pin : Form
    {
        string ss = "";
        public Admin_change_pin(string s)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label7.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin aa = new Admin(ss);
            aa.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                if (textBox1.Text == "")
                {
                    label3.Text = "Please Fill this!";
                }
                if (textBox2.Text == "")
                {
                    label5.Text = "Please Fill this!";
                }
                if (textBox3.Text == "")
                {
                    label7.Text = "Please Fill this!";
                }
                MessageBox.Show("Please Fill the Following DATA!");
            }
            else
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Abid Shafique\documents\visual studio 2013\Projects\Bank Management System\Bank Management System\Bank.mdf;Integrated Security=True");
                sqlcon.Open();
                string query = "select * from manager_login where manager_name= '" + ss + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                SqlDataReader dr = cmd.ExecuteReader();
                int pass = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pass = int.Parse(dr[3].ToString());
                    }
                }
                sqlcon.Close();
                if (check_amount(textBox1.Text) == false || check_amount(textBox2.Text) == false || check_amount(textBox3.Text) == false || textBox1.Text.Length > 6 || textBox2.Text.Length > 6 || textBox3.Text.Length > 6)
                {
                    if (textBox1.Text.Length > 6 || textBox2.Text.Length > 6 || textBox3.Text.Length > 6)
                    {
                        MessageBox.Show("All Entered Data Must be have greater than 6 degits length......!");
                    }
                    else
                    {
                        MessageBox.Show("All Entered Data Must be Integers Type......!");
                    }
                }
                else
                {
                    if (int.Parse(textBox1.Text) != pass)
                    {
                        MessageBox.Show("Your Old Verify Code is Incorrect");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        if (textBox2.Text != textBox3.Text)
                        {
                            MessageBox.Show("New Verify Code doesn't Match with Retype New Verify Code!");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                        }
                        else
                        {
                            if (textBox2.Text.Length >= 4 && textBox2.Text.Length <= 6)
                            {
                                if (textBox1.Text == textBox2.Text)
                                {
                                    MessageBox.Show("Your Old and New Verify Code are same please Write new one!");
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                    textBox3.Text = "";
                                }
                                else
                                {
                                    sqlcon.Open();
                                    SqlCommand cmd1 = sqlcon.CreateCommand();
                                    cmd1.CommandType = CommandType.Text;
                                    cmd1.CommandText = "update manager_login set verify_code = " + textBox2.Text + " where manager_name='" + ss + "'";
                                    cmd1.ExecuteNonQuery();
                                    sqlcon.Close();
                                    MessageBox.Show("Verify Code Updated Successfully!");
                                    this.Hide();
                                    Admin aa = new Admin(ss);
                                    aa.ShowDialog();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Verify can be of at least 4 digits and maximum 6 degits.....!");
                            }
                        }
                    }
                }
            }
        }
    }
}

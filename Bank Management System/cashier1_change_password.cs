﻿using System;
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
    public partial class cashier1_change_password : Form
    {
        string ss = "";
        public cashier1_change_password(string s)
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
        private void cashier1_change_password_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            cashier1 s = new cashier1(ss);
            s.ShowDialog();
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
                string job = "";
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
                        job = dr[7].ToString();
                    }
                }
                pass = trimspcaces(pass);
                sqlcon.Close();
                if (textBox1.Text != pass)
                {
                    MessageBox.Show("Your Old Password is Incorrect");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    if (textBox2.Text != textBox3.Text)
                    {
                        MessageBox.Show("New Password doesn't Match with Retype New Password!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        if (textBox1.Text == textBox2.Text)
                        {
                            MessageBox.Show("Your Old and New Password are same please Write new one!");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                        }
                        else
                        {
                            sqlcon.Open();
                            SqlCommand cmd1 = sqlcon.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "update emp_login set password = '" + textBox2.Text + "' where login_name='" + ss + "'";
                            cmd1.ExecuteNonQuery();
                            sqlcon.Close();
                            MessageBox.Show("Password Updated Successfully!");
                            if(job == "cashier1")
                            {
                                this.Hide();
                                cashier1 u = new cashier1(ss);
                                u.ShowDialog();

                            }
                            else if(job == "cashier2")
                            {
                                this.Hide();
                                cashier2 u = new cashier2(ss);
                                u.ShowDialog();

                            }
                            else if (job == "accountant")
                            {
                                this.Hide();
                                accountant u = new accountant(ss);
                                u.ShowDialog();
                            }
                            else if (job == "Data Modifier")
                            {
                                this.Hide();
                                Data_Modifier u = new Data_Modifier(ss);
                                u.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome w = new Welcome();
            w.ShowDialog();
        }
    }
}

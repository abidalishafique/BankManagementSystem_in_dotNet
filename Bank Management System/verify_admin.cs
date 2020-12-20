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
    public partial class verify_admin : Form
    {
        string ss = "", form_number = "";
        public verify_admin(string s, string n)
        {
            InitializeComponent();
            label1.Text = label1.Text + s + ".....";
            ss = s;
            form_number = n;
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin aa = new Admin(ss);
            aa.ShowDialog();
        }

        private void verify_admin_Load(object sender, EventArgs e)
        {

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
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e )
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
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
                string pass = "";
                int pin = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        pass = dr[2].ToString();
                        pin = int.Parse(dr[3].ToString());
                    }
                }
                pass = trimspcaces(pass);
                sqlcon.Close();
                if (check_amount(textBox3.Text) == false)
                {
                    MessageBox.Show("Enteres Verify Code is invalid.......!");
                }
                else
                {
                    if (textBox2.Text != pass || pin != int.Parse(textBox3.Text))
                    {
                        MessageBox.Show("Your Password or Verify Code is Incorrect please Enter correct Passward and Verify Code!...");
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        if(form_number == "1")
                        {
                            this.Hide();
                            Employee_Data ee = new Employee_Data(ss);
                            ee.ShowDialog();
                        }
                        else
                        {
                            this.Hide();
                            Account_Data aa = new Account_Data(ss);
                            aa.ShowDialog();
                        }
                    }
                }
            }
        }
    }
}

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
    public partial class Create_account : Form
    {
        string ss = "";
        string joinn = "";
        public Create_account(string s)
        {
            InitializeComponent();
            label1.Text = label1.Text + s + ".....";
            ss = s;
        }

        private void Create_account_Load(object sender, EventArgs e)
        {
            joinn = dateTimePicker1.Text;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pp_TextChanged(object sender, EventArgs e)
        {
            label19.Text = "";
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
            accountant a = new accountant(ss);
            a.ShowDialog();
        }

        private void first_name_TextChanged(object sender, EventArgs e)
        {
            label11.Text = "";
        }

        private void last_name_TextChanged(object sender, EventArgs e)
        {
            label17.Text = "";
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            label21.Text = "";
        }

        private void cn_TextChanged(object sender, EventArgs e)
        {
            label18.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label23.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label32.Text = "";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                textBox4.UseSystemPasswordChar = false;
            }
            else
            {
                textBox4.UseSystemPasswordChar = true;
            }
        }

        private void nat_TextChanged(object sender, EventArgs e)
        {
            label13.Text = "";
        }

        private void sal_TextChanged(object sender, EventArgs e)
        {
            label16.Text = "";
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            label8.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label26.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label29.Text = "";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
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
        private void state_TextChanged(object sender, EventArgs e)
        {
            label20.Text = "";
        }

        private void city_TextChanged(object sender, EventArgs e)
        {
            label22.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || first_name.Text == "" || last_name.Text == "" || city.Text == "" || email.Text == "" || pp.Text == "" || id.Text == "" || cn.Text == "" || nat.Text == "" || sal.Text == "" || state.Text == "" || comboBox1.Text == "" || textBox5.Text == "" || comboBox2.Text == "")
            {
                if(first_name.Text == "")
                {
                    label11.Text = "Please Fill this!";
                }
                if (comboBox2.Text == "")
                {
                    label36.Text = "Please Fill this!";
                }
                if(textBox5.Text == "")
                {
                    label34.Text = "Please Fill this!";
                }
                if (textBox1.Text == "" )
                {
                    label23.Text = "Please Fill this!";
                }
                if(textBox2.Text == "" )
                {
                    label26.Text = "Please Fill this!";
                }
                if(textBox3.Text == "")
                {
                    label29.Text = "Please Fill this!";
                }
                if(textBox4.Text == "")
                {
                    label32.Text = "Please Fill this!";
                }
                if(last_name.Text == "" )
                {
                    label17.Text = "Please Fill this!";
                }
                if(city.Text == "")
                {
                    label22.Text = "Please Fill this!";
                }
                if(email.Text == "")
                {
                    label8.Text = "Please Fill this!";
                }
                if(pp.Text == "")
                {
                    label19.Text = "Please Fill this!";
                }
                if(id.Text == "")
                {
                    label21.Text = "Please Fill this!";
                }
                if(cn.Text == "")
                {
                    label18.Text = "Please Fill this!";
                }
                if(nat.Text == "")
                {
                    label13.Text = "Please Fill this!";
                }
                if(sal.Text == "")
                {
                    label16.Text = "Please Fill this!";
                }
                if(state.Text == "")
                {
                    label20.Text = "Please Fill this!";
                }
                if(comboBox1.Text == "")
                {
                    label33.Text = "Please Fill this!";
                }
                MessageBox.Show("Please Fill the Following DATA!");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Abid Shafique\documents\visual studio 2013\Projects\Bank Management System\Bank Management System\Bank.mdf;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from user_login where user_name = '" + textBox2.Text + "'";
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close();
                    MessageBox.Show("Some User already has this User Name so please change User Name");
                }
                else
                {
                    con.Close();
                    if(textBox3.Text != textBox4.Text)
                    {
                        
                        MessageBox.Show("Password does Match with Retype Password");
                    }
                    else
                    {
                        con.Open();
                        string query = "select * from emp_login where login_name= '" + ss + "'";
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = con;
                        cmd1.CommandText = query;
                        cmd1.ExecuteNonQuery();

                        SqlDataReader dr1 = cmd1.ExecuteReader();
                        string pass = "";
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                pass = dr1[2].ToString();
                            }
                        }
                        pass = trimspcaces(pass);
                        if (textBox5.Text != pass)
                        {
                            MessageBox.Show("Accountant Password is Incorrect please Enter correct Passward!...");
                            con.Close();
                        } 
                        else
                        {
                            con.Close();
                            if (check_amount(textBox1.Text) && double.Parse(textBox1.Text) >= 500)
                            {
                                if(check_amount(pp.Text)==false || check_amount(sal.Text)==false)
                                {
                                    MessageBox.Show("Your Salary or Postal Code Must contains Degits...............");
                                }
                                else
                                {
                                    con.Open();
                                    string user_pass = textBox4.Text;
                                    string user_nam = textBox2.Text;
                                    SqlCommand cmd2 = new SqlCommand();
                                    cmd2.Connection = con;
                                    cmd2.CommandText = "insert into user_login(user_name,passward) values('" + user_nam + "','" + user_pass + "')";
                                    cmd2.ExecuteNonQuery();
                                    con.Close();

                                    con.Open();
                                    SqlCommand cmd3 = new SqlCommand();
                                    cmd3.Connection = con;
                                    cmd3.CommandText = "select user_id from user_login where user_name ='" + user_nam + "'";
                                    cmd3.ExecuteNonQuery();
                                    SqlDataReader dr3 = cmd3.ExecuteReader();
                                    int user_id = -1;
                                    while (dr3.Read())
                                    {
                                        user_id = int.Parse(dr3[0].ToString());
                                    }
                                    con.Close();
                                    string first_name1 = first_name.Text, last_name1 = last_name.Text, id_card1 = id.Text, contact1 = cn.Text, join_date1 = joinn, email1 = email.Text;
                                    string dob1 = dateTimePicker1.Text, city1 = city.Text, state1 = state.Text, nationality1 = nat.Text, gender1 = comboBox1.Text, postal_code1 = pp.Text;
                                    double sal1 = double.Parse(sal.Text), balance = double.Parse(textBox1.Text);
                                    string type = comboBox2.Text;
                                    con.Open();
                                    SqlCommand cmd4 = new SqlCommand();
                                    cmd4.Connection = con;
                                    cmd4.CommandText = "insert into user_table(user_id,first_name,last_name,email,contact_no,join_date,id_card_no) values(" + user_id.ToString() + ",'" + first_name1 + "','" + last_name1 + "','" + email1 + "','" + contact1 + "','" + join_date1 + "','" + id_card1 + "')";
                                    cmd4.ExecuteNonQuery();
                                    con.Close();

                                    con.Open();
                                    SqlCommand cmd5 = new SqlCommand();
                                    cmd5.Connection = con;
                                    cmd5.CommandText = "insert into detail(user_id,date_of_birth,city,state,nationality,salary,gender,postal_code) values(" + user_id.ToString() + ",'" + dob1 + "','" + city1 + "','" + state1 + "','" + nationality1 + "'," + sal1 + ",'" + gender1 + "','" + postal_code1 + "')";
                                    cmd5.ExecuteNonQuery();
                                    con.Close();

                                    con.Open();
                                    SqlCommand cmd6 = new SqlCommand();
                                    cmd6.Connection = con;
                                    cmd6.CommandText = "insert into account(User_id,Balance,account_type) values(" + user_id.ToString() + "," + balance + ",'" + type + "')";
                                    cmd6.ExecuteNonQuery();
                                    con.Close();

                                    con.Open();
                                    SqlCommand cmd7 = new SqlCommand();
                                    cmd7.Connection = con;
                                    cmd7.CommandText = "select account_number from account where User_id =" + user_id.ToString();
                                    cmd7.ExecuteNonQuery();
                                    SqlDataReader dr7 = cmd7.ExecuteReader();
                                    int account_id = -1;
                                    while (dr7.Read())
                                    {
                                        account_id = int.Parse(dr7[0].ToString());
                                    }
                                    con.Close();
                                    account_number aaaa = new account_number(user_nam, "000099999" + account_id.ToString());
                                    aaaa.ShowDialog();
                                    MessageBox.Show("Account created successfully......");
                                    this.Hide();
                                    accountant a = new accountant(ss);
                                    a.ShowDialog();
                                }
                            }
                            else
                            {
                                MessageBox.Show("You enter an invalid Balance value and Remember value must b greate the or equal 500");
                            }
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label33.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox5.UseSystemPasswordChar = false;
            }
            else
            {
                textBox5.UseSystemPasswordChar = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label34.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label36.Text = "";
        }
    }
}

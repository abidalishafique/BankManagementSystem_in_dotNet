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
    public partial class check_balance : Form
    {
        string ss = "";
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Abid Shafique\documents\visual studio 2013\Projects\Bank Management System\Bank Management System\Bank.mdf;Integrated Security=True");
        
        public check_balance(string s)
        {
            InitializeComponent();
            label1.Text = label1.Text + s + ".....";
            ss = s;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f = new Welcome();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Option u = new User_Option(ss);
            u.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            User_Option u = new User_Option(ss);
            u.ShowDialog();
        }

        private void check_balance_Load(object sender, EventArgs e)
        {
            sqlcon.Open();
            SqlCommand cmd1 = sqlcon.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select account_number,Balance from account,user_login where user_name='" + ss + "' and account.User_id = user_login.user_id";
            cmd1.ExecuteNonQuery();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    textBox3.Text = "000099999" + dr1[0].ToString();
                    textBox1.Text = dr1[1].ToString();
                }
            }
            sqlcon.Close();
        }
    }
}

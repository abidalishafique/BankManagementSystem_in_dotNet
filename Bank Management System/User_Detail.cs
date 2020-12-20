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
    public partial class User_Detail : Form
    {
        string ss = "";
        public User_Detail(string s)
        {
            InitializeComponent();
            label1.Text = label1.Text + s + ".....";
            ss = s;
        }

        private void User_Detail_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Abid Shafique\documents\visual studio 2013\Projects\Bank Management System\Bank Management System\Bank.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select user_table.user_id,first_name,last_name,email,contact_no,join_date,id_card_no,date_of_birth,city,state,nationality,salary,gender,postal_code from user_table,user_login,detail where user_table.user_id = user_login.user_id and user_login.user_id = detail.user_id and user_name = '"+ss+"'";
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {

                while(dr.Read())
                {
                    first_name.Text = dr[1].ToString();
                    last_name.Text = dr[2].ToString();
                    email.Text = dr[3].ToString();
                    cn.Text = dr[4].ToString();
                    jd.Text = dr[5].ToString();
                    id.Text = dr[6].ToString();
                    dob.Text = dr[7].ToString();
                    city.Text = dr[8].ToString();
                    state.Text = dr[9].ToString();
                    nat.Text = dr[10].ToString();
                    sal.Text = dr[11].ToString();
                    gen.Text = dr[12].ToString();
                    pp.Text = dr[13].ToString();
                }
            }
            else
            {
                MessageBox.Show("No Data");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Option u = new User_Option(ss);
            u.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome f = new Welcome();
            f.ShowDialog();
        }
    }
}

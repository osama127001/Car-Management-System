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

namespace UserAdminLoginForm
{
    public partial class UserLogin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4MCFE92\SQLEXPRESS;Initial Catalog=Car Management System;Integrated Security=True");

        public UserLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Employee_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //adding input parameters
                cmd.Parameters.Add("@E_ID", SqlDbType.Int, 50).Value = textBox1.Text.Trim();
                cmd.Parameters.Add("@E_Pass", SqlDbType.NVarChar, 50).Value = textBox2.Text.Trim();
                cmd.Parameters.Add("@E_Pass", SqlDbType.NVarChar, 50).Value = textBox2.Text.Trim();
                cmd.Parameters.Add("@E_Pass", SqlDbType.NVarChar, 50).Value = textBox2.Text.Trim();

                //adding output parameter
                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Int));
                cmd.Parameters["@flag"].Direction = ParameterDirection.Output;

                //calling sp
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();

                //converting output to int
                try
                {
                    flag = (int)cmd.Parameters["@flag"].Value;
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }

                //saving value in flag
                flag = (int)cmd.Parameters["@flag"].Value;

                cmd.ExecuteNonQuery();
                con.Close();

                if (flag == 1)
                {
                    EmployeeHomePage EHS = new EmployeeHomePage();
                    this.Hide();
                    EHS.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Info, Please Check Again!");
                }
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception Exp)
            {
                MessageBox.Show("Admin cannot login due following error: " + Exp.Message);
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
            }   

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int flag = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Admin_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //adding input parameters
                cmd.Parameters.Add("@A_ID", SqlDbType.Int, 50).Value = textBox1.Text.Trim();
                cmd.Parameters.Add("@A_Pass", SqlDbType.NVarChar, 50).Value = textBox2.Text.Trim();

                //adding output parameter
                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Int));
                cmd.Parameters["@flag"].Direction = ParameterDirection.Output;

                //calling sp
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();

                //converting output to int
                try
                {
                    flag = (int)cmd.Parameters["@flag"].Value;
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }

                //saving value in flag
                flag = (int)cmd.Parameters["@flag"].Value;

                cmd.ExecuteNonQuery();
                con.Close();

                if (flag == 1)
                {
                    AdminHomePage AHS = new AdminHomePage();
                    this.Hide();
                    AHS.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Info, Please Check Again!");
                }
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception Exp)
            {
                MessageBox.Show("Admin cannot login due following error: " + Exp.Message);
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
            }   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

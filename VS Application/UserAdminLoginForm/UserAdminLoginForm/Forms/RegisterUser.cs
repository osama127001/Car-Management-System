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
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4MCFE92\SQLEXPRESS;Initial Catalog=Car Management System;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Register_user", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //adding input parameters
                cmd.Parameters.Add("@U_Name", SqlDbType.NVarChar, 50).Value = textBox1.Text.Trim();
                cmd.Parameters.Add("@U_Password", SqlDbType.NVarChar, 50).Value = textBox2.Text.Trim();
                cmd.Parameters.Add("@U_CNIC", SqlDbType.NVarChar, 50).Value = textBox3.Text.Trim();
                cmd.Parameters.Add("@U_Address", SqlDbType.NVarChar, 50).Value = textBox4.Text.Trim();
                cmd.Parameters.Add("@U_NTN", SqlDbType.NVarChar, 50).Value = textBox5.Text.Trim();

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
                catch(Exception E)
                {
                    MessageBox.Show(E.Message);
                }

                //saving value in flag
                flag = (int)cmd.Parameters["@flag"].Value;

                cmd.ExecuteNonQuery();
                con.Close();

                if (flag == 1)
                {
                    MessageBox.Show("User Registered!");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            catch(Exception Exp){
                MessageBox.Show("User cannot be registered due to following error: " + Exp.Message);
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminHomePage AHP = new AdminHomePage();
            this.Hide();
            AHP.Show();
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {

        }
    }
}

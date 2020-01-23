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

namespace Car_Management_System
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4MCFE92\SQLEXPRESS;Initial Catalog=Car Management System;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adminName = "NULL";
            int flag = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Admin_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //adding input parameters
                cmd.Parameters.Add("@U_ID", SqlDbType.Int, 50).Value = textBox1.Text.Trim();
                cmd.Parameters.Add("@A_Pass", SqlDbType.NVarChar, 50).Value = textBox2.Text.Trim();

                //adding output parameter
                cmd.Parameters.Add(new SqlParameter("@A_IDD", SqlDbType.Int));
                cmd.Parameters["@A_IDD"].Direction = ParameterDirection.Output;

                //adding output parameter
                cmd.Parameters.Add(new SqlParameter("@A_Name", SqlDbType.NVarChar, 50));
                cmd.Parameters["@A_Name"].Direction = ParameterDirection.Output;

                //calling sp
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();

                //converting output to int
                try
                {
                    flag = (int)cmd.Parameters["@A_IDD"].Value;
                    adminName = cmd.Parameters["@A_Name"].Value.ToString();
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }

                //saving value in flag
                flag = (int)cmd.Parameters["@A_IDD"].Value;
                adminName = cmd.Parameters["@A_Name"].Value.ToString();

                cmd.ExecuteNonQuery();
                con.Close();

                if (flag != 0)
                {
                    Forms.AdminHomePage AHS = new Forms.AdminHomePage(flag);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string adminName = "NULL";
            int flag = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Employee_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //adding input parameters
                cmd.Parameters.Add("@U_ID", SqlDbType.Int, 50).Value = textBox1.Text.Trim();
                cmd.Parameters.Add("@E_Pass", SqlDbType.NVarChar, 50).Value = textBox2.Text.Trim();

                //adding output parameter
                cmd.Parameters.Add(new SqlParameter("@E_IDD", SqlDbType.Int));
                cmd.Parameters["@E_IDD"].Direction = ParameterDirection.Output;

                //adding output parameter
                cmd.Parameters.Add(new SqlParameter("@E_Name", SqlDbType.NVarChar, 50));
                cmd.Parameters["@E_Name"].Direction = ParameterDirection.Output;

                //calling sp
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();

                //converting output to int
                try
                {
                    flag = (int)cmd.Parameters["@E_IDD"].Value;
                    adminName = cmd.Parameters["@E_Name"].Value.ToString();
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }

                //saving value in flag
                flag = (int)cmd.Parameters["@E_IDD"].Value;
                adminName = cmd.Parameters["@E_Name"].Value.ToString();

                cmd.ExecuteNonQuery();
                con.Close();

                if (flag != 0)
                {
                    Forms.EmployeeHomePage EHP = new Forms.EmployeeHomePage(flag);
                    this.Hide();
                    EHP.Show();
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
                MessageBox.Show("Employee cannot login due following error: " + Exp.Message);
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}

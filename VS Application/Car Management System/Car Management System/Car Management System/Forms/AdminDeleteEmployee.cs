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

namespace Car_Management_System.Forms
{
    public partial class AdminDeleteEmployee : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4MCFE92\SQLEXPRESS;Initial Catalog=Car Management System;Integrated Security=True");
        int user_id;
        public AdminDeleteEmployee(int u_id)
        {
            this.user_id = u_id;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminHomePage ahp = new AdminHomePage(this.user_id);
            this.Hide();
            ahp.Show();
        }

        private void AdminDeleteEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = -1;
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Enter Correct Requirements!");
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Delete_Employee_by_Admin", con);
                cmd.Parameters.Add("@U_ID", SqlDbType.Int).Value = textBox1.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Int));
                cmd.Parameters["@flag"].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable DT = new DataTable();
                DT.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = DT;
                con.Close();
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

                if (flag == 1)
                {
                    MessageBox.Show("Employee Deleted!");
                }
                else
                {
                    MessageBox.Show("Employee Not Deleted!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}

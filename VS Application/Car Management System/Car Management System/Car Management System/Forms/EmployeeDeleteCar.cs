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
    public partial class EmployeeDeleteCar : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4MCFE92\SQLEXPRESS;Initial Catalog=Car Management System;Integrated Security=True");

        int employee_id;
        public EmployeeDeleteCar(int e_id)
        {
            this.employee_id = e_id;
            InitializeComponent();
        }

        private void EmployeeDeleteCar_Load(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("sp_Delete_Car_by_user", con);
                cmd.Parameters.Add("@U_ID", SqlDbType.Int).Value = this.employee_id;
                cmd.Parameters.Add("@C_ID", SqlDbType.Int).Value = textBox1.Text.Trim();
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
                    MessageBox.Show("Car Deleted!");
                }
                else
                {
                    MessageBox.Show("Car Not Deleted!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmployeeHomePage ehp = new EmployeeHomePage(this.employee_id);
            this.Hide();
            ehp.Show();
        }
    }
}

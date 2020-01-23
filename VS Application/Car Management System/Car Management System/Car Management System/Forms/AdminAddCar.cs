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
    public partial class AdminAddCar : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4MCFE92\SQLEXPRESS;Initial Catalog=Car Management System;Integrated Security=True");
        int user_id;

        public AdminAddCar(int u_id)
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

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = -1;
            int car_id = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Register_car", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //adding input parameters
                cmd.Parameters.Add("@Car_Numberplate", SqlDbType.NVarChar, 50).Value = textBox1.Text.Trim();
                cmd.Parameters.Add("@Car_EngineNo", SqlDbType.NVarChar, 50).Value = textBox2.Text.Trim();
                cmd.Parameters.Add("@Car_ChassisNo", SqlDbType.NVarChar, 50).Value = textBox3.Text.Trim();
                cmd.Parameters.Add("@Car_Name", SqlDbType.NVarChar, 50).Value = textBox4.Text.Trim();
                cmd.Parameters.Add("@Car_Model", SqlDbType.NVarChar, 50).Value = textBox5.Text.Trim();
                cmd.Parameters.Add("@Car_Color", SqlDbType.NVarChar, 50).Value = textBox6.Text.Trim();
                cmd.Parameters.Add("@User_ID", SqlDbType.Int, 50).Value = this.user_id;


                //adding output parameter
                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Int));
                cmd.Parameters["@flag"].Direction = ParameterDirection.Output;

                //adding output parameter
                cmd.Parameters.Add(new SqlParameter("@iddd", SqlDbType.Int));
                cmd.Parameters["@iddd"].Direction = ParameterDirection.Output;

                //calling sp
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();

                //converting output to int
                try
                {
                    flag = (int)cmd.Parameters["@flag"].Value;
                    car_id = (int)cmd.Parameters["@iddd"].Value;
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
                    MessageBox.Show("Car Registered! Car Id is: " + car_id);
                }
                else
                {
                    MessageBox.Show("Invalid User!");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            catch (Exception Exp)
            {
                MessageBox.Show("User cannot be registered due to following error: " + Exp.Message);
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
        }

        private void AdminAddCar_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class AdminSearchCar : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4MCFE92\SQLEXPRESS;Initial Catalog=Car Management System;Integrated Security=True");
        int user_id;

        public AdminSearchCar(int u_id)
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
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Search_by_car", con);
                cmd.Parameters.Add("@U_ID", SqlDbType.Int).Value = this.user_id;
                cmd.Parameters.Add("@C_ID", SqlDbType.Int).Value = textBox1.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.Int));
                cmd.Parameters["@flag"].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable DT = new DataTable();
                DT.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = DT;
                con.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void AdminSearchCar_Load(object sender, EventArgs e)
        {

        }
    }
}

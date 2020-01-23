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
    public partial class AdminHomePage : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4MCFE92\SQLEXPRESS;Initial Catalog=Car Management System;Integrated Security=True");

        public AdminHomePage()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchCar SC = new SearchCar();
            this.Hide();
            SC.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SearchEmployee SE = new SearchEmployee();
            this.Hide();
            SE.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterCar RC = new RegisterCar();
            this.Hide();
            RC.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterUser RU = new RegisterUser();
            this.Hide();
            RU.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteCar DC = new DeleteCar();
            this.Hide();
            DC.Show();
        }

        private void AdminHomePage_Load(object sender, EventArgs e)
        {

        }
    }
}

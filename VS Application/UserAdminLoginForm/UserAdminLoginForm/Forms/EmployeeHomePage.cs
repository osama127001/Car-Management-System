using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAdminLoginForm
{
    public partial class EmployeeHomePage : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4MCFE92\SQLEXPRESS;Initial Catalog=Car Management System;Integrated Security=True");

        public EmployeeHomePage()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchCar SC = new SearchCar();
            this.Hide();
            SC.Show();
        }

        private void EmployeeHomePage_Load(object sender, EventArgs e)
        {

        }
    }
}

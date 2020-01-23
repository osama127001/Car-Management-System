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
    public partial class AdminHomePage : Form
    {
        int u_id;
        public AdminHomePage(int user_id)
        {
            this.u_id = user_id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminAddCar aac = new AdminAddCar(u_id);
            this.Hide();
            aac.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminAddEmployee aae = new AdminAddEmployee(u_id);
            this.Hide();
            aae.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminDeleteCar adc = new AdminDeleteCar(u_id);
            this.Hide();
            adc.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminSearchEmployee ase = new AdminSearchEmployee(u_id);
            this.Hide();
            ase.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminSearchCar asc = new AdminSearchCar(u_id);
            this.Hide();
            asc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminDeleteEmployee ade = new AdminDeleteEmployee(u_id);
            this.Hide();
            ade.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminHomePage_Load(object sender, EventArgs e)
        {

        }
    }
}
